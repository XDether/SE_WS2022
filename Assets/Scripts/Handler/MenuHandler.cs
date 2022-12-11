using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreField;
    private string scoreText;
    private Highscores scores;

    void Start()
    {
        scores = new Highscores();

        ScoreField.text = scores.GetScores();
    }

    public void StartScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
