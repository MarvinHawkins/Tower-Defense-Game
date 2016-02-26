using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


    //variables
    public int playerMoney = 0; //hardcoded for now, but may set on start
    //public int lives = 20; //set the player;s lives will set dynamically
    public int wave; //Set the total number of waves 


    public Text waveLabel;   //label used to set the number of waves
    public Text goldLabel;
    public Text healthLabel;
    public Text stats;

    public GameObject[] healthIndicator;
    public GameObject[] nextWaveLabels;

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
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
            // 4 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }



    // Use this for initialization
    void Start()
    {
        Money = 10000;
       // Wave = 0; // set wave initial wave to 0
        Health = 5;

    }
}
