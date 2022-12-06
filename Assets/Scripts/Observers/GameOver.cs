using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : Observer
{
    private float time;
    private GameObject gameOverPannel;
    private TextMeshProUGUI gameOverText;
    private string name;
    public GameOver(float time, string name, GameObject gameOverPannel, TextMeshProUGUI gameOverText)
    {
        this.time = time;
        this.gameOverPannel = gameOverPannel;
        this.gameOverText = gameOverText;
    }

    public void setTime(float time){
        this.time = time;
    }

    public override void OnNotify()
    {
        gameOverText.text = "Sup " + name + " your time was " + time +" s";
        gameOverPannel.SetActive(true);
        //Time.timeScale = 0;
    }

}