using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Highscores: Observer
{

    private string path;
    private List<Score> scores;
    private BinaryFormatter formatter;

    public Highscores()
    {
        formatter = new BinaryFormatter();
        path = Application.persistentDataPath + "/Score.list";
        Debug.Log(path);

        LoadScores();
    }

    public void AddScore(string name, float score)
    {
        scores.Add(new Score(name,score));
        CreateScores();
    }

    public void LoadScores()
    {

        if(File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            scores = formatter.Deserialize(stream) as List<Score>;
            stream.Close();
        }
        else
        {
            Debug.LogError("Scores are empty creating new scores");
            scores = new List<Score>();
            CreateScores();
        }
    }

    public string GetScores(){

        List<Score> tmpScores = scores;  
        List<Score> bestScores = new List<Score>();
        Score best = new Score("Empty", 0);

        int req = tmpScores.Count; 

        for(int i = 0; i < req; i++)
        {
            if(i >= 10){
                break;
            }

            foreach(Score score in tmpScores)
            {
                if(best.GetScore() <= score.GetScore())
                {
                    best = score;   
                }
            }

            bestScores.Add(best);
            tmpScores.Remove(best);
            best = new Score("Empty", 0);
        }

        string text = "";

        for(int i  = 0; i< bestScores.Count; i++)
        {
            if(i >= 10)
            {
                return text;
            }
            text = text + bestScores[i].GetName() + " : " + bestScores[i].GetScore() + "\n";
        }
        return text;
    }

    public void CreateScores()
    {   
        FileStream stream = new FileStream(path , FileMode.Create);
        formatter.Serialize(stream, scores);
        stream.Close();
    }

    public override void OnNotify()
    {

    }
}