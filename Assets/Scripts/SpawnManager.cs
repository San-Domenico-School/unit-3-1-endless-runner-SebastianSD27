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
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Stop spawning obstacles at Game Over
    private void SpawnObstacle()
    {
        if (!GameManager.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }

        else
        {
            CancelInvoke();
        }
          
    }
}
