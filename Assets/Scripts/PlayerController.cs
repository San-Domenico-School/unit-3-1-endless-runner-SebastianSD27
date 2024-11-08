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
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
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

        isOnGround = true;

        Physics.gravity *= gravityModifier;
    }

    private void OnJump(InputValue input)
    {
        if (isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground") ;
        {
            isOnGround = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }



}