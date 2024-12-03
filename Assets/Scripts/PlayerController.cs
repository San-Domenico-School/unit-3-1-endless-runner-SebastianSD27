using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*******************************************
 * Attached to MonoBehavior
 * Gives player controls, audio, particles, etc
 * 
 * Sebastian Balakier
 * 11/6/24, Version 1.0
 ******************************************/

public class PlayerController : MonoBehaviour
{
    // fields
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 1;
    [SerializeField] private ParticleSystem explosionsParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    public bool gameOver { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Player's jump force
    private void OnJump(InputValue input)
    {
        if (isOnGround && !gameOver)
        {
            playerAnimator.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 3.0f);
        }
    }

    // Player collision with ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground") 
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetTrigger("Death_b");
            explosionsParticle.Play();
            Debug.Log("Explosion is Playing: " + explosionsParticle.isPlaying);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            
        }    
    }



}