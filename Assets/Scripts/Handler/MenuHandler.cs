using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Main Menu Handler
/// </summary>
public class MenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreField;
    private Highscores scores;

    void Start()
    {
        scores = new Highscores();
        ScoreField.text = scores.GetScores();
    }

    /// <summary>
    /// Starts a scene
    /// </summary>
    /// <param name="index">index of the scene</param>
    public void StartScene(int index)
    {
        if(GameObject.Find("AudioController"))
        {
            GameObject.Find("AudioController").GetComponent<AudioController>().Play("Theme");
            GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        }
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// quits the application
    /// </summary>
    public void Quit()
    {
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        Application.Quit();
    }
}
