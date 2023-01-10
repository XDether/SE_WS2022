using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUiHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private GameObject gameController;

    private Highscores scores;
    private bool alreadySubmited;

    void Start(){
        scores = new Highscores();
    }

    public void SubmitScore(){
        if(!alreadySubmited)
        {
            scores.AddScore(nameField.text, gameController.GetComponent<GameController>().getTime());
            nameField.text = "Submited!!";
            alreadySubmited = true;
        }
        GameObject.Find("AudioController").GetComponent<AudioController>().Play("ButtonClick");
        SceneManager.LoadScene(0);
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

