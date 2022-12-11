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

    public List<Score> GetScores(){
        return scores;
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