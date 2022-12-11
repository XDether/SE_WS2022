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

    private string playerName;
    private Highscores scores;

    private static GameState gameState;
    private Subject timeSubject, gameOverSubject ,everyTickSubject;
    private CameraMovement cameraMovement;
    private Watch watch;
    private StageGenerator stageGenerator;
    private GameOver gameOver;
    private bool hasNotifiedTime, isGameOver,doOnce;
    private float camHalfHeight,camHalfWidth, startTime;
    // Start is called before the first frame update
    void Start()
    {   scores = new Highscores();
        startTime = Time.time;
        gameState = GameState.Start;
        
        playerName = "unkown";

        timeSubject = new Subject();
        everyTickSubject = new Subject();

        watch = new Watch(startTime, timer);
        cameraMovement = new CameraMovement(speed, increment, cam);
        stageGenerator = new StageGenerator(stageObjects,HalfStageWidth);
        gameOver = new GameOver(watch.getSpentTime(),playerName, gameOverPannel, gameOverText);
        
        //Getting camera width and height
        Camera came = Camera.main;
        camHalfHeight = came.orthographicSize;
        camHalfWidth = came.aspect * camHalfHeight;
        
        timeSubject.AddObserver(cameraMovement);
        everyTickSubject.AddObserver(watch);
        everyTickSubject.AddObserver(stageGenerator);
        everyTickSubject.AddObserver(gameOver);
    }

    // Update is called once per frame
    void Update()
    {
        inputHandler.GetComponent<InputHandler>().HandleInput();
        
        everyTickSubject.Notify();
        if(!hasNotifiedTime){
                StartCoroutine(NotifyTimeAfter(incrementAfter));
        } 

        if(player.transform.position.x < cam.transform.position.x - camHalfWidth - 3)
        {
            gameState = GameState.Over;
            gameOver.setTime(watch.getSpentTime());

            inputHandler.GetComponent<InputHandler>().setCanMove(false);
            everyTickSubject.RemoveObserver(watch);
            everyTickSubject.RemoveObserver(stageGenerator);

            if(!doOnce){
                scores.AddScore(playerName, watch.getSpentTime());
                doOnce = true;
            }
        }
        else
        {
            gameState = GameState.OnGoing;
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

    public static GameState GetGameState()
    {
        return gameState;
    }
}