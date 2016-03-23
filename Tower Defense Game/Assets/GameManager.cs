using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    //variables
    public int playerMoney = 0; //hardcoded for now, but may set on start
    public int playerScore = 0;
    public int towerScore = 0; //use to get the 
 
    public Text waveLabel;   //label used to set the number of waves
    public Text goldLabel;
    public Text healthLabel;
    public Text stats;

    public List<GameObject> builtTowers;
    

    public GameObject[] healthIndicator;
    public GameObject[] nextWaveLabels;

    public bool gameOver = false;
    public bool isWin = false;
    public bool isLose = false;
    public buttonScript ButtonScript;
    public GameObject canvasWinPanel;


   

    //property of the money object
    public int Money
    {

        get { return playerMoney; }
        set
        {
            playerMoney = value;
            goldLabel.GetComponent<Text>().text = "Money: " + playerMoney;
        }
    }
  

    

    private int health;
    public int Health
    {
        get { return health; }

        // Study this more
        set
        {
            
            // 2
            health = value;
            healthLabel.text = "HEALTH: " + health;
            // 3
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                //GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
               // gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
           
        }
    }

    private int wave;
    public int Wave
    {
        get { return wave; }
        set
        {
            wave = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                    //To do add animation
                }
            }
            waveLabel.text = "WAVE: " + (wave + 1);
        }
    }

    void Update()
    {
        if (gameOver)
        {
            if (health <= 0)
            {
                isLose = true;
            }
            else
            {
              
                GameWin();
            }
        }
    }

   
    void GameWin()
    {
        Debug.Log("You Won!!!");
        canvasWinPanel.SetActive(true);
        // playerScore = towerScore;   

        //Do calculations


        playerScore = (playerMoney * 1000) + (health*1000)+(towerScore*1);
            
            //Load the new level
            //To Do Show animation of win
            // SceneManager.LoadScene(0);
    }

    void GameLoss()
    {
        Debug.Log("You Lost!!!");
        //To Do Show animation of loss
        SceneManager.LoadScene(0);
        //Player Loses The game

    }

    // Use this for initialization
    void Start()
    {
        Money = 1000;
        Wave = 0; // set wave initial wave to 0
        Health = 20;

        ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
        canvasWinPanel = ButtonScript.winPanel; //Should send this unit's stats to the panel

    }



}
