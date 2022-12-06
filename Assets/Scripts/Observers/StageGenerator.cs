using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator: MonoBehaviour
{
    private List<GameObject> spawnedObjects;
    private bool canInstantiate;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private float HalfStageWidht;
    private Camera cam;
    float oldCamPos, camHalfWidth, camHalfHeight;
    public void Start(){
        spawnedObjects = new List<GameObject>();
        cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
        oldCamPos = cam.transform.position.x - camHalfWidth - HalfStageWidht;
    }

    public void FixedUpdate()
    {   
        if(oldCamPos + camHalfWidth + HalfStageWidht <= cam.transform.position.x)
        {
            oldCamPos = cam.transform.position.x;
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject newSpawn = Instantiate(gameObjects[Random.Range(0, gameObjects.Length)]);
        newSpawn.transform.position = new Vector3(cam.transform.position.x + camHalfWidth + HalfStageWidht,0,0);
        spawnedObjects.Add(newSpawn);
        
        if(spawnedObjects.Count > 2)
        {
            GameObject toRemove = spawnedObjects[0];
            spawnedObjects.Remove(toRemove);
            Destroy(toRemove);
        }
    }
}