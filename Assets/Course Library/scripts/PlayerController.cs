using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //privates
    private Rigidbody playerRb;
    private Animator playerAnim;
    
    //publics
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {   //The *= means original value muliplied and is equal to gravity modifier.
        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //When Space is pressed, If the player is on the ground, player jumps.
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
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
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            //Animations
            dirtParticle.Play();
            dirtParticle.Stop();
        }
    }
}
