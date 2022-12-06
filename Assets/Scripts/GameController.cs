using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] private float speed, increment, incrementAfter;
    [SerializeField] private GameObject cam, player, inputHandler;

    private Subject timeSubject, gameOverSubject;
    private CameraMovement cameraMovement;
    private bool hasNotifiedTime, isGameOver;
    private float camHalfHeight,camHalfWidth, startTime;


    // Start is called before the first frame update
    void Start()
    {   
        timeSubject = new Subject();
        gameOverSubject = new Subject();

        Camera came = Camera.main;
        camHalfHeight = came.orthographicSize;
        camHalfWidth = came.aspect * camHalfHeight;
        
        cameraMovement = new CameraMovement(speed, increment, cam);
        timeSubject.AddObserver(cameraMovement);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        inputHandler.GetComponent<InputHandler>().HandleInput();
        if(!hasNotifiedTime){
            StartCoroutine(NotifyTimeAfter(incrementAfter));
        } 

        if(player.transform.position.x < cam.transform.position.x - camHalfWidth - 3)
        {
            gameOverSubject.Notify();
            Time.timeScale = 0;
        }
    }

    void FixedUpdate(){
        cameraMovement.yFollow(player.transform);
    }

    IEnumerator NotifyTimeAfter(float seconds)
    {
        hasNotifiedTime = true;
        yield return new WaitForSeconds(seconds);
        hasNotifiedTime = false;
        speed = speed + increment;
        inputHandler.GetComponent<InputHandler>().setSpeed(speed+4);
        timeSubject.Notify();
    }
}