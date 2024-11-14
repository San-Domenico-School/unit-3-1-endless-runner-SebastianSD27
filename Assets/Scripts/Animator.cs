using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump()
    {
        if (isOnGround && !gameOver)
        {
            playerAnimator.setTrigger("Jump_trig");
        }
    }
}
