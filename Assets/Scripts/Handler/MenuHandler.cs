using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreField;
    private Highscores scores;

    void Start()
    {
        scores = new Highscores();
        ScoreField.text = scores.GetScores();
    }

    public void StartScene(int index)
    {
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        Application.Quit();
    }
}
