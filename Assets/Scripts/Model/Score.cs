using System;

[Serializable]
public class Score
{
    private string name;
    private float score;
    public Score(string name, float score)
    {   
        this.name = name;
        this.score = score;
    }

    public string GetName()
    {
        return name;
    }

    public float GetScore()
    {
        return score;
    }

}