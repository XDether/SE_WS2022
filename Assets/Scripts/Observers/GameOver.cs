using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// Handles the game over state
/// </summary>
public class GameOver : Observer
{
    private float time;
    private GameObject gameOverPannel;
    private TextMeshProUGUI gameOverText;
    private string name;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="time">Time of the player</param>
    /// <param name="name">Player Name</param>
    /// <param name="gameOverPannel">Game Over Pannel to show</param>
    /// <param name="gameOverText">Game Over Text</param>
    public GameOver(float time, string name, GameObject gameOverPannel, TextMeshProUGUI gameOverText)
    {
        this.time = time;
        this.gameOverPannel = gameOverPannel;
        this.gameOverText = gameOverText;
        this.name = name;
    }

    /// <summary>
    /// Sets the reached time
    /// </summary>
    /// <param name="time">Time in seconds</param>
    public void setTime(float time){
        this.time = time;
    }

    /// <summary>
    /// Notifys GameOver if the gamestate is over start game over pannel
    /// </summary>
    public override void OnNotify()
    {
        if(GameController.GetGameState() == GameState.Over)
        {
                gameOverText.text = "Sup " + name + " your time was " + time +" s";
                gameOverPannel.SetActive(true);

                if(GameObject.Find("AudioController"))
                {
                    GameObject.Find("AudioController").GetComponent<AudioController>().Stop("Theme");
                }
        }
    }


}