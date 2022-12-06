using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores: Observer
{
    List<float> scores;
    List<string> names;

    public Highscores()
    {

    }

    public void addScore(string name, float score)
    {
        
    }

    public override void OnNotify()
    {
        if (GameObject.Find("Scores") != null)
        {
            GameObject.Find("Scores").GetComponent<TextMesh>().text = "";
        }
    }

    public void UpdateScores()
    {

    }
}