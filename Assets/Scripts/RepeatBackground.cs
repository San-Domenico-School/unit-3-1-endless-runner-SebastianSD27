using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************
* Attached to MonoBehavior
* Repeats background to simulate player movement
*
* Sebastian Balakier
* 11/8/24, Version 1.0
*******************************************/

public class RepeatBackground : MonoBehaviour
{
    //fields
    private Vector3 startPos;
    private float repeatWidth;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
