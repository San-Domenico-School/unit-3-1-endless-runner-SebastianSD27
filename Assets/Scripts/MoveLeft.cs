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
    public float speed = 10f;                 
    private float leftBound = -15;


   
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x <= leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
