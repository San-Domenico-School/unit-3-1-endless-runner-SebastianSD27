using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************
* Attached to MonoBehavior
* Moves obstacles, collectables, powerups, and poisons to the left
*
* Sebastian Balakier
* 11/8/24, Version 1.0
*******************************************/

public class MoveLeft : MonoBehaviour
{
    //fields
    private float speed = 15f;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x <= leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
