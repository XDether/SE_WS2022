using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] private float speed, increment, incrementAfter;
    [SerializeField] private GameObject cam,player;

    private Subject timeSubject, gameOverSubject;
    private CameraMovement cameraMovement;
    private bool hasNotifiedTime, isGameOver;

    // Start is called before the first frame update
    void Start()
    {   
        timeSubject = new Subject();
        gameOverSubject = new Subject();

        cameraMovement = new CameraMovement(speed, increment, cam);
        timeSubject.AddObserver(cameraMovement);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasNotifiedTime){
            StartCoroutine(NotifyTimeAfter(incrementAfter));
        }

        if(isGameOver)
        {
            gameOverSubject.Notify();
        }
    }

    IEnumerator NotifyTimeAfter(float seconds)
    {
        hasNotifiedTime = true;
        yield return new WaitForSeconds(seconds);
        hasNotifiedTime = false;
        timeSubject.Notify();
    }
}