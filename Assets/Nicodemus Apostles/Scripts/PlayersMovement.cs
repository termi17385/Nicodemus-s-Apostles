using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    public float jumpHeight;
    public float moveSpeed;


    private Rigidbody2D charRigidBody;

    public bool grounded;
    public LayerMask whatIsGrounded;        //reminder to make a layer for "grounded"

    private Collider2D charCollieder;

    // Start is called before the first frame update
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody2D>();                  //defining player rigidbody and colliders
        charCollieder = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(charCollieder, whatIsGrounded);     //defines grounded boolean as being true when the player is touching the ground


        charRigidBody.velocity = new Vector2(moveSpeed, charRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))               //sets control of jumping to space key
        {
            if (grounded)                                    //only works if grounded = true
            {

                charRigidBody.velocity = new Vector2(charRigidBody.velocity.x, jumpHeight);     //changes y velocity of player to jumpHeight
            }
        }
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
