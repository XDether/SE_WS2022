using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/// <summary>
/// Score List
/// </summary>
public class Highscores
{

    private string path;
    private List<Score> scores;
    private BinaryFormatter formatter;
    
    /// <summary>
    /// Constructor
    /// </summary>
    public Highscores()
    {
        formatter = new BinaryFormatter();
        path = Application.persistentDataPath + "/Score.list";
        Debug.Log(path);

        LoadScores();
    }

    /// <summary>
    /// Adds a score to the list
    /// </summary>
    /// <param name="name">name of the player</param>
    /// <param name="score">reached score</param>
    public void AddScore(string name, float score)
    {
        scores.Add(new Score(name,score));
        CreateScores();
    }

    /// <summary>
    /// Loads the score list from a file
    /// </summary>
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

    /// <summary>
    /// gets the score list
    /// </summary>
    /// <returns>List of Scores</returns>
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

        foreach(Score score in bestScores)
        {
            text = text + score.GetName() + " / " + score.GetScore() + "\n";
        }

        return text;
    }

    /// <summary>
    /// Creates a new score list file
    /// </summary>
    public void CreateScores()
    {   
        FileStream stream = new FileStream(path , FileMode.Create);
        formatter.Serialize(stream, scores);
        stream.Close();
    }
}