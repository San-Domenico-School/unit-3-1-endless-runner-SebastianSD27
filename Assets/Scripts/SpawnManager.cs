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
    [SerializeField] private GameObject tShirtPrefab;
    [SerializeField] private GameObject badApplePrefab;
    [SerializeField] private GameObject badBananaPrefab;
    [SerializeField] private GameObject coffeePrefab;
    [SerializeField] private GameObject donutPrefab;
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private float spawnYRange = 3f;
    private float spawnXOffset = 10f;
    private Transform playerTransform;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), startDelay, repeatRate);
        //InvokeRepeating("SpawnCollectable", startDelay, repeatRate);
    }

    // Spawn gameObejcts
    private void SpawnObject()
    {
        // Spawn objects if gameOver is false
        if (!GameManager.gameOver)
        {
           Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

            GameObject prefabToSpawn = GetRandomItem();

            float randomY = Random.Range(-spawnYRange, spawnYRange);

            Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnXOffset, randomY, 0);

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // GameObject  = Random.value < .4f ? tShirtPrefab : badApplePrefab;

            // Instantiate(prefabToSpawn, spawnPos, obstaclePrefab.transform.rotation);

            // float randomY = Random.Range(-spawnYRange, spawnYRange);

            // Vector3 spawnPosition = new Vector3(playerTransform.position.x + spawnXOffset, randomY, 0);


        }
        // If gameOver is not false, stop spawning obejcts
        else
        {
            CancelInvoke();
        }
    }

    private GameObject GetRandomItem()
    {
        GameObject[] items = { badApplePrefab, badBananaPrefab, coffeePrefab, donutPrefab, tShirtPrefab };

        int index = Random.Range(0, items.Length);
        return items[index];
    }
}
