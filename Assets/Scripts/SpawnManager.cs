using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2f;
    private float spawnInterval = 4f;

    private CameraController cameraController;
    private float cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        cameraPosition = GameObject.Find("Main Camera").transform.position.x;
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(Random.Range(10, 11) + cameraPosition, 0, 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        // if (!gameManager.gameOver)
        if (true)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }

    void Update()
    {
        
    }
}
