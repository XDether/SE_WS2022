using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Handles the Main Game UI
/// </summary>
public class GameUiHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private GameObject gameController;

    private Highscores scores;
    private bool alreadySubmited;

    void Start()
    {
        scores = new Highscores();
    }

    /// <summary>
    /// Submits the reached time after game over state
    /// </summary>
    public void SubmitScore()
    {
        if (!alreadySubmited)
        {
            scores.AddScore(nameField.text, gameController.GetComponent<GameController>().getTime());
            nameField.text = "Submited!!";
            alreadySubmited = true;
        }
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Starts a scene
    /// </summary>
    /// <param name="index"> Scene Index Number</param>
    public void StartScene(int index)
    {
        if (index == 1)
        {
            GameObject.Find("AudioController").GetComponent<AudioController>().Play("Theme");
        }
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        SceneManager.LoadScene(index);


    }


    /// <summary>
    /// Quits the application
    /// </summary>
    public void Quit()
    {
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        Application.Quit();
    }
}

