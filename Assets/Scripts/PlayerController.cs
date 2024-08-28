using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //this is a variable for a rigidbody that is attached to the player.
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float jumpForce;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        //I can only get this component using the following line of code
        //becuase the rigidbody2d is attached to the player and this script
        //is also attached to the player. 
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //if the player presses a move left, d move right
        //"Horizontal" is defined in the input section of the project settings
        //the line below will return:
        //0  - no button pressed
        //1  - right arrow or d pressed
        //-1 - left arrow or a pressed
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);

    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
    }
}
