using System;
/// <summary>
/// Represents a Score
/// </summary>
[Serializable]
public class Score
{
    private string name;
    private float score;
    /// <summary>
    /// Score constructor
    /// </summary>
    /// <param name="name">Name of the player</param>
    /// <param name="score">reached score</param>
    public Score(string name, float score)
    {   
        this.name = name;
        this.score = score;
    }

    /// <summary>
    /// returns the name of the player
    /// </summary>
    /// <returns>Player Name</returns>
    public string GetName()
    {
        return name;
    }
    
    /// <summary>
    /// returns the score of the player
    /// </summary>
    /// <returns>Score in seconds</returns>
    public float GetScore()
    {
        return score;
    }

}