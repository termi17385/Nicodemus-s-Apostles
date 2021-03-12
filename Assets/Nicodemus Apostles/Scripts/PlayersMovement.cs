using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersMovement : MonoBehaviour
{
    // We just have jump height
    // The player wont be moving but the speed will change how fast and how many of the obstacles are spawned
    private float jumpHeight;
    private float playerSpeed;

    // Player Score
    private float playerScore;
    public Text playerScoreDisplay;
    
    // Basic collider stuff
    private Collider2D charCollieder;
    private Animator playerAnimator;
    private Rigidbody2D charRigidBody;

    // Checking if grounded to jump.
    private bool grounded;
    // Checking if he is delivering a heart.
    private bool heartDelivered;
    // Checking if he is picking up a heart.
    private bool heartPickedUp;
    // Checking if he is dead.
    private bool dead;

    // Checking if he is holding a heart.
    private bool holdingHeart;

    [SerializeField] private LayerMask whatIsGrounded;        //reminder to make a layer for "grounded"
    [SerializeField] private LayerMask whatIsNurse;        //reminder to make a layer for "Nurse"
    [SerializeField] private LayerMask whatIsEsky;        //reminder to make a layer for "Esky"
    [SerializeField] private LayerMask whatIsObstacle;        //reminder to make a layer for "obstacle"


    // Start is called before the first frame update
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody2D>();                  //defining player rigidbody and colliders
        charCollieder = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();

        // Set our variables here
        jumpHeight = 15;
        playerSpeed = 10;
        dead = false;
        holdingHeart = true;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if grounded if colliding with Ground layer.
        grounded = Physics2D.IsTouchingLayers(charCollieder, whatIsGrounded);     //defines grounded boolean as being true when the player is touching the ground

        // Check if heart delivered if colliding with Nurse layer.
        heartDelivered = Physics2D.IsTouchingLayers(charCollieder, whatIsNurse);

        // Check if heart picked up if colliding with Esky layer.
        heartPickedUp = Physics2D.IsTouchingLayers(charCollieder, whatIsEsky);

        // Check if Dead if colliding with Obstacle layer.
        dead = Physics2D.IsTouchingLayers(charCollieder, whatIsObstacle);
        

        // If touching obstacle die.
        if (dead)
        {
            playerDeath();
        }


        // Check if Heart is delivered.
        if (heartDelivered)
        {
            playerHeartDelivered();

            // Stops checking collision with Doctor.
            heartDelivered = false;
        }


        // Check if Heart is delivered.
        if (heartPickedUp)
        {
            playerHeartPickedUp();

            // Stops checking collision with Esky.
            heartPickedUp = false;
        }


        // Player Jumps
        if (Input.GetKeyDown(KeyCode.Space))               //sets control of jumping to space key
        {
            if (grounded)                                    //only works if grounded = true
            {
                charRigidBody.velocity = new Vector2(charRigidBody.velocity.x, jumpHeight);     //changes y velocity of player to jumpHeight
            }
        }

        // Player Score displayed as whole number
        playerScore += playerSpeed * Time.deltaTime;
        playerScoreDisplay.text = playerScore.ToString("F0");

        // Animation switch
        playerAnimator.SetFloat("Speed", playerSpeed);
        playerAnimator.SetBool("Grounded", grounded);
    }

    private void playerDeath()
    {
        // pause game
        // enable pause menu
        // disable player controls
    }

    private void playerHeartDelivered()
    {
        // Increase game speed.
        Time.timeScale += 0.2f;

        // If holding a heart drop it and get a bonus.
        if (holdingHeart)
        {
            // Increase score.
            playerScore += 1000;
            
                // sprite change
            // !!! NEED TO DO !!! //

            // Drop heart.
            holdingHeart = false;
        }
    }
    private void playerHeartPickedUp()
    {
        // Picks up a heart.
        holdingHeart = true;
    }




    //public GameManager theGameManager;          //just defining method to call the game manager script
    //implementing a new game restart function later, this one does not work.
    //private void OnCollisionEnter2D(Collision2D other)      //collider to detect when player has hit game borders, triggers restart
    //{
    //    if(other.gameObject.tag == "killbox")               
    //        {
    //       theGameManager.RestartGame();
    //    }
    //}


}
