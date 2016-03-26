using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    //variables
    public int playerMoney = 0; //hardcoded for now, but may set on start
    public int playerScore = 0;
    public int towerScore = 0; //use to get the 

    public int highScore = 0;
    public string highScoreKey = "HighScore"; 

    public Text waveLabel;   //label used to set the number of waves
    public Text goldLabel;
    public Text healthLabel;
    public Text scoreLabel;
    public Text hiScoreLabel;
    public Text endGameLabel;
    public Text stats;

   public GameObject nextWaveLabels;

   public buttonScript ButtonScript;
   public GameObject canvasWinPanel;

    public bool gameOver = false;   


   
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
                //Play animation
                nextWaveLabels.GetComponent<Animator>().SetTrigger("NextWave");
                  
            }
            waveLabel.text = "WAVE: " + (wave + 1);
        }
    }

    //Assign the player a score based on money left, health left and value of towers
    public void calcScore()
    {
        //If our scoree is greter than highscore, set new higscore and save.
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, playerScore);
            PlayerPrefs.Save();
        }
        playerScore = (playerMoney * 1) + (health * 10) + (towerScore * 1);
        scoreLabel.GetComponent<Text>().text = "Your Score: " + playerScore;
        hiScoreLabel.GetComponent<Text>().text = "High Score: " + highScore;

    }

    void Update()
        {
            if (gameOver)
                {
                    calcScore();
                    canvasWinPanel.SetActive(true);

                    if (health <= 0)
                        {
                            GameLoss();
                        }
                   else
                        {
                            GameWin();
                        }
                }
        }

    void GameWin()
    {

        endGameLabel.GetComponent<Text>().text = "You Won! ";
        Debug.Log("You Won!!!");
        //Load the new level
         
    }

    void GameLoss()
        {
            endGameLabel.GetComponent<Text>().text = "You Lost! ";
            Debug.Log("You Lost!!!");
            //To Do Show animation of loss
        }

    // Use this for initialization
    void Start()
    {
        Money = 10000;
        Wave = 0; // set wave initial wave to 0
        Health = 3;
        //Get the highScore from player prefs if it is there, 0 otherwise.
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);


    }
}