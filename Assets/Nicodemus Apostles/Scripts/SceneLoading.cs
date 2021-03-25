using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    
    public void ExitGame()
    {
        //Exits the game when ran as a build executable.
        Application.Quit();
        
        //If the game is being ran inside of Unity Editor, this exits out of play mode instead.
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void PlayGame() // When play button is pressed loads the game scene (Scene 2)
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    float prevTimeScale = 1; // float that is set to save the previous time scale when game is paused.
    public void Pause()// When game is paused sets time scale to 0 and sets float to previous timescale before pause.
    {
        prevTimeScale = Time.timeScale;
        Time.timeScale = 0;
        
    }

    public void Resume()// When game is resumed the timescale is returned to the timescale prior to pause
    {
        Time.timeScale = prevTimeScale;

    }

    public void MainMenu()// Loads main menu scene(set to scene 1) 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void RestartGame() // restarts the game by loading the game scene (scene 2) and resets timescale to normal (1)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

}
