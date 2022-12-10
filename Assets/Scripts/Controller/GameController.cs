using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed, increment, incrementAfter, HalfStageWidth;
    [SerializeField] private GameObject cam, player, inputHandler, gameOverPannel;
    [SerializeField] private GameObject [] stageObjects;
    [SerializeField] private TextMeshProUGUI timer, gameOverText;

    private Subject timeSubject, gameOverSubject ,everyTicksSubject;
    private CameraMovement cameraMovement;
    private Watch watch;
    
    private StageGenerator stageGenerator;
    private GameOver gameOver;


    private bool hasNotifiedTime, isGameOver;
    private float camHalfHeight,camHalfWidth, startTime;


    // Start is called before the first frame update
    void Start()
    {   
        startTime = Time.time;

        timeSubject = new Subject();
        gameOverSubject = new Subject();
        everyTicksSubject = new Subject();

        watch = new Watch(startTime, timer);
        cameraMovement = new CameraMovement(speed, increment, cam);
        stageGenerator = new StageGenerator(stageObjects,HalfStageWidth);

        gameOver = new GameOver(watch.getSpentTime(),"Joe Mawa", gameOverPannel, gameOverText);
        
        Camera came = Camera.main;

        camHalfHeight = came.orthographicSize;
        camHalfWidth = came.aspect * camHalfHeight;
        
        timeSubject.AddObserver(cameraMovement);
        gameOverSubject.AddObserver(gameOver);
        everyTicksSubject.AddObserver(watch);
        everyTicksSubject.AddObserver(stageGenerator);

    }

    // Update is called once per frame
    void Update()
    {
        inputHandler.GetComponent<InputHandler>().HandleInput();
        
        everyTicksSubject.Notify();

        if(!hasNotifiedTime){
            StartCoroutine(NotifyTimeAfter(incrementAfter));
        } 

        if(player.transform.position.x < cam.transform.position.x - camHalfWidth - 3)
        {

            gameOver.setTime(watch.getSpentTime());
            gameOverSubject.Notify();
            inputHandler.GetComponent<InputHandler>().setCanMove(false);
            timeSubject.RemoveObserver(cameraMovement);
            gameOverSubject.RemoveObserver(gameOver);
            everyTicksSubject.RemoveObserver(watch);
            everyTicksSubject.RemoveObserver(stageGenerator);
            cameraMovement.Stop();
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