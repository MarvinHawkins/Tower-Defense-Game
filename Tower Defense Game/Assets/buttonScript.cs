using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//T his script handles the building of a tower on a click

public class buttonScript : MonoBehaviour {

    public GameObject[] towers; //set up array of tower options AVAIABLE TO THE PLAYER
    public GameObject selectedTower; //assign the clicked gameobject
    public GameObject towerPlaced;
    public Transform currentSpot; //Parent of placed tower
    //Classes
    public GameManager gameManager;  //Find the game manager class
    public GameObject statPanel; //hold ref of the panel
    public GameObject labelParent;
    public GameObject winPanel;
    public GameObject tooltipPanel; //The panel that opens when the player hovers over an open spot
    public GameObject buildOptionsPanel;
    
    public TowerData towerdata; //Ref of the tower script
    public Button[] upgradeButton;
    public Text[] statLabels;


   


    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        statPanel = GameObject.FindGameObjectWithTag("Stats");
        labelParent = GameObject.Find("Canvas/StatsPanel/labels");
        upgradeButton = statPanel.GetComponentsInChildren<Button>();
        statLabels = labelParent.GetComponentsInChildren<Text>();
        statPanel.SetActive(false);
        winPanel.SetActive(false);
        buildOptionsPanel.SetActive(false);
        tooltipPanel.SetActive(false);
        towerdata = selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>();
    }


   
    public bool canPlaceTower()
    {
        towerPlaced = selectedTower.GetComponent<Spot>().towerPlaced; //check to see if a tower is  on thew open spot
        return towerPlaced == null;
    }

   

    public void buildTower(int tower)
    {

        if (canPlaceTower())
        {

            int cost = towers[tower].GetComponent<TowerData>().cost;
              
            
            if (gameManager.playerMoney >= cost)
            {
                //deduct cost
                GameObject newTower = Instantiate(towers[tower], selectedTower.transform.position, Quaternion.identity) as GameObject;
                newTower.transform.SetParent(selectedTower.transform);
                selectedTower.GetComponent<Spot>().towerPlaced = newTower;  //Set the open spot to the  tower selected by the player
                gameManager.Money -= towers[tower].GetComponent<TowerData>().cost;  //set the property which sets the actaul variable
                gameManager.towerScore += towers[tower].GetComponent<TowerData>().sellRate;
                buildOptionsPanel.SetActive(false);//Close the tower menu
                selectedTower.GetComponent<BoxCollider2D>().enabled = false;
                //Close tooltip panel
               // tooltipPanel.GetComponent<Text>().text = "";
                tooltipPanel.SetActive(false);
                
            }         
        }
        else
        {
            Debug.Log("A tower has been placed!" + selectedTower.GetComponent<Spot>().towerPlaced);
        }

    }   

    //Set up sales

    public void sellTower()
    {

        //First make sure that a tower is selected or not empty
        if(selectedTower.GetComponentInParent<Spot>() !=null)
            {
                //Sell the tower
            
                //Destroy(selected object)
                //REMOVE THE VALUE FROM TOWER SCORE
                gameManager.towerScore -= selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().sellRate; //Remove the current towers sell rate
                //Return a certain amount of money to the player
                gameManager.Money += selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().sellRate; //Sell the tower for the same cost
                //Destroy the tower
                //Debug.Log("Destroy this object");
                statPanel.SetActive(false);//Close the tower menu
                selectedTower.GetComponentInParent<Spot>().GetComponent<BoxCollider2D>().enabled = true; //turn the spots collider back on
                Destroy(selectedTower.GetComponentInParent<Spot>().towerPlaced);   //Delete the old tower
                tooltipPanel.SetActive(false);

        }

    }


    //upgrade Tower
    public void upgradeTower()
    {
        if (selectedTower.GetComponentInParent<Spot>() != null)
            {
                //Get parent spot first
                GameObject nextTower = Instantiate(selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().myUpgrade, selectedTower.transform.position, Quaternion.identity) as GameObject;     
                nextTower.transform.SetParent(currentSpot.transform);
                //Remove the current towers sell rate from the player's tower score
                gameManager.towerScore -= selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().sellRate; 
                gameManager.towerScore += selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().myUpgrade.GetComponent<TowerData>().sellRate;

                gameManager.Money -= selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().upgradeRate; //Sell the tower for the same cost
                //make the upgraded tower the tower in the spot
                selectedTower.GetComponentInParent<Spot>().towerPlaced = nextTower;
                statPanel.SetActive(false);//Close the tower menu
            //Delete the old tower
            Destroy(selectedTower); //may need to fix
         
            }
    }

    //Other Button Script stuff
    public void playAgain()
        {

            SceneManager.LoadScene(1);
        }

   

    public void endGame()
        {
            SceneManager.LoadScene(0);
        }

    public void closeBuildPanel()
    {
        buildOptionsPanel.SetActive(false);//Close the tower menu
    }

    public void closeTurretPanel()
    {
        statPanel.SetActive(false);//Close the tower menu
    }




}