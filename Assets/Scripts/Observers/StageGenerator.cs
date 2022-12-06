using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator: Observer
{
    private List<GameObject> spawnedObjects;
    private GameObject[] gameObjects;
    public StageGenerator(GameObject[] gameObjects)
    {
        this.spawnedObjects = new List<GameObject>();
        this.gameObjects = gameObjects;

    }
     
    public override void OnNotify()
    {

    }
}