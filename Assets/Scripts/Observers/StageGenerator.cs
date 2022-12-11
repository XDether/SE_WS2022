using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator: Observer
{
    private List<GameObject> spawnedObjects;
    private bool canInstantiate;
    private GameObject[] gameObjects;
    private Camera cam;
    private float oldCamPos, camHalfWidth, camHalfHeight,HalfStageWidht;

    public StageGenerator(GameObject[] gameObjects, float HalfStageWidth)
    {
        spawnedObjects = new List<GameObject>();
        cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
        oldCamPos = cam.transform.position.x - camHalfWidth - HalfStageWidht;

        this.HalfStageWidht = HalfStageWidth;
        this.gameObjects = gameObjects;
    }

    public override void OnNotify()
    {
        if(oldCamPos + camHalfWidth + HalfStageWidht <= cam.transform.position.x)
        {
            oldCamPos = cam.transform.position.x;
            Spawn();
        }

    }

    public void Spawn()
    {
        GameObject newSpawn = GameObject.Instantiate(gameObjects[Random.Range(0, gameObjects.Length)]);
        newSpawn.transform.position = new Vector3(cam.transform.position.x + camHalfWidth + HalfStageWidht,0,0);
        spawnedObjects.Add(newSpawn);

        if(spawnedObjects.Count > 2)
        {
            GameObject toRemove = spawnedObjects[0];
            spawnedObjects.Remove(toRemove);
            GameObject.Destroy(toRemove);
        }
    }
}