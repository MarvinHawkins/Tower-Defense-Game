using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    //high score stuff
    public Text highScoreLabel; //hold ref of the panel
    public int highScore;
    public string highScoreKey = "HighScore";
    // Use this for initialization

    void Start ()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        //highScoreLabel.GetComponent<Text>().text = "Hi Score: " + PlayerPrefs.GetInt(highScoreKey);
        highScoreLabel.gameObject.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }


    public void showHiScore()
    {
        highScoreLabel.GetComponent<Text>().text = "Hi Score: " + PlayerPrefs.GetInt(highScoreKey);
        highScoreLabel.gameObject.SetActive(true);
    }

    public void resetScore()
    {
        highScoreLabel.gameObject.SetActive(false);
        PlayerPrefs.SetInt(highScoreKey, 0);

    }

}
