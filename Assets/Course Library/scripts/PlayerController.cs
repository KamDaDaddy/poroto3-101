using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //privates
    private Rigidbody playerRb;
    
    //publics
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        //The *= means original value muliplied and is equal to gravity modifier.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //When Space is pressed, If the player is on the ground, player jumps.
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    //separate box checked and not checked tic on the inspector
    private void OnCollisionEnter(Collision collision)
    {
        //if player collided with "ground" it's true on inspector.
        //if collided with obstacle "game over" on console.
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("HAHAHAHA BYE BYE!");
        }
    }
}
