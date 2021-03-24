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

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    float prevTimeScale = 1;
    public void Pause()
    {
        prevTimeScale = Time.timeScale;
        Time.timeScale = 0;
        
    }

    public void Resume()
    {
        Time.timeScale = prevTimeScale;
            //(PlayersMovement.heartsCollected * 0.2) ;
            // 1 + hearts delivered *0.2 to resume as same speed as previous
            // in theory save hearts delivered +1 each time delivered(
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Debug.Log(Time.timeScale);
        Time.timeScale = 1;
        
        SceneManager.LoadScene(2);
        Debug.Log(Time.timeScale);
        Time.timeScale = 1;
    }

}
