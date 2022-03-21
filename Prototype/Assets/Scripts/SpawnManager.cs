using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject[] objectPrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, -2.5f);
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //InvokeRepeating("SpawnObject", startDelay, spawnInterval);
    }

  
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
    /*void SpawnObject()
    {
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), -2);
        int index = Random.Range(0, objectPrefabs.Length);
        
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }*/
    
}
