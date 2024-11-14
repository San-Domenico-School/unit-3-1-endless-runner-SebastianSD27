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
    private Animator playerAnimation;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    public bool gameOver { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();

        isOnGround = true;

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
        
        }
    }

    // Player's jump force
    private void OnJump(InputValue input)
    {
        if (isOnGround && !gameOver)
        {
            playerAnimation.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // Player collision with ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground") 
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnimation.SetTrigger("Death_trig");
            playerAnimation.SetInteger("DeathType_int", 1); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }



}