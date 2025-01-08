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
    private float normalSpeed;
    private static float speed;
    private float leftBound = -15;
    public static bool isSpeedingUp;
    private static bool isCoroutineRunning;

    private void Start()
    {
        normalSpeed = 10;
        if (!isSpeedingUp)
        {
            speed = normalSpeed;
        }
        
    }

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

        if (transform.position.x <= leftBound && gameObject.CompareTag("PowerUp"))
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= leftBound && gameObject.CompareTag("Debuff"))
        {
            Destroy(gameObject);
        }

        if(isSpeedingUp && !isCoroutineRunning)
        {
            StartCoroutine("NormalSpeed");
        }
    }

    IEnumerator NormalSpeed()
    {
        isCoroutineRunning = true;
        speed = 18;
        Debug.Log(speed);
        yield return new WaitForSeconds(7);
        isSpeedingUp = false;
        speed = normalSpeed;
        isCoroutineRunning = false;
        Debug.Log(speed);
    }


}