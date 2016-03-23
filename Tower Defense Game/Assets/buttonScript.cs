using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//T his script handles the building of a tower on a click

public class buttonScript  : MonoBehaviour {

    public GameObject[] towers; //set up array of tower options AVAIABLE TO THE PLAYER
    public GameObject selectedTower; //assign the clicked gameobject
    public GameObject towerPlaced;
    public Transform currentSpot; //Parent of placed tower
    //Classes
    public GameManager gameManager;  //Find the game manager class
    public GameObject statPanel; //hold ref of the panel
    public GameObject winPanel;
    public TowerData towerdata; //Ref of the tower script
    public Button[] upgradeButton;
    

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        statPanel = GameObject.FindGameObjectWithTag("Stats");
        upgradeButton = statPanel.GetComponentsInChildren<Button>();
        statPanel.SetActive(false);
        winPanel.SetActive(false);
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
                gameManager.builtTowers.Add(newTower);
      
            }         
        }
        else
        {
            Debug.Log("A tower has been placed!" + selectedTower.GetComponent<Spot>().towerPlaced);
        }

    }   

    //Set up sales

    public void sellTower(){

        //First make sure that a tower is selected or not empty
        
        if(selectedTower.GetComponentInParent<Spot>() !=null)
        {
            //Sell the tower
            //Destroy the tower
            Debug.Log("Destroy this object");
            gameManager.builtTowers.Add(selectedTower.GetComponentInParent<Spot>().towerPlaced);
            Destroy(selectedTower.GetComponentInParent<Spot>().towerPlaced);

            //Destroy(selected object)
            //Return a certain amount of money to the player
            gameManager.Money += selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().sellRate; //Sell the tower for the same cost

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
            gameManager.towerScore -= selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().sellRate; //Remove the current towers sell rate
            gameManager.towerScore += selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().myUpgrade.GetComponent<TowerData>().sellRate;
            gameManager.Money -= selectedTower.GetComponentInParent<Spot>().towerPlaced.GetComponent<TowerData>().upgradeRate; //Sell the tower for the same cost
            //make the upgraded tower the tower in the spot
            selectedTower.GetComponentInParent<Spot>().towerPlaced = nextTower;
            
            //Delete the old tower
            Destroy(selectedTower); //may need to fix
         
        }

    }

}