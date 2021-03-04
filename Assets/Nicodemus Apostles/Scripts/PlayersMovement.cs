using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersMovement : MonoBehaviour
{
    // We just have jump height
    // The player wont be moving but the speed will change how fast and how many of the obstacles are spawned
    // If you want to make it 'LOOK' like he is going faster we can increase his sprite speed over time but tbh dont bother
    private float jumpHeight;
    private float playerSpeed;

    // Player Score
    private float playerScore;
    public Text playerScoreDisplay;

    private Collider2D charCollieder;
    private Animator playerAnimator;
    private Rigidbody2D charRigidBody;

    private bool grounded;
    private bool dead;

    [SerializeField] private LayerMask whatIsGrounded;        //reminder to make a layer for "grounded"
    [SerializeField] private LayerMask whatIsNurse;        //reminder to make a layer for "grounded"
    [SerializeField] private LayerMask whatIsObstacle;        //reminder to make a layer for "grounded"


    // Start is called before the first frame update
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody2D>();                  //defining player rigidbody and colliders
        charCollieder = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();

        // Set our variables here
        jumpHeight = 10;
        playerSpeed = 10;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if grounded
        grounded = Physics2D.IsTouchingLayers(charCollieder, whatIsGrounded);     //defines grounded boolean as being true when the player is touching the ground

        // Check if Dead
        dead = Physics2D.IsTouchingLayers(charCollieder, whatIsObstacle);
        if (dead == true)
        {
            playerDeath();
        }


        if (Physics2D.IsTouchingLayers(charCollieder, whatIsObstacle) == true)
        {
            playerHeartDelivered();
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
        // speed increase
        // increase score
        // sprite change
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
