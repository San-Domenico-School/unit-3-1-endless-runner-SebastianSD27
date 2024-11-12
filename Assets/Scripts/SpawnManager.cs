using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************
     * Attached to MonoBehavior
     * Spawns player and obstacles
     *
     * Sebastian Balakier
     * 11/8/24, Version 1.0
*********************************************/

public class SpawnManager : MonoBehaviour
{
    //fields
    [SerializeField] private GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }

        else
        {
            CancelInvoke();
        }
          
    }
}
