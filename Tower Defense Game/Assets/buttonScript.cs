using UnityEngine;
using System.Collections;

//T his script handles the building of a tower on a click

public class buttonScript : MonoBehaviour {

    public GameObject[] towers; //set up array of tower options AVAIABLE TO THE PLAYER
    public GameObject selectedTower; //assign the clicked gameobject
    public GameObject towerPlaced;
    public GameManager gameManager;  //Find the game manager class
    public GameObject statPanel; //hold ref of the panel




    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        statPanel = GameObject.FindGameObjectWithTag("Stats");
       // statPanel.SetActive(false);
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

            int cost = towers[tower].GetComponent<TowerData>().levels[0].cost;
              
            
            if (gameManager.playerMoney >= cost)
            {
                //deduct cost
                GameObject newTower = Instantiate(towers[tower], selectedTower.transform.position, Quaternion.identity) as GameObject;
                newTower.transform.SetParent(selectedTower.transform);
                selectedTower.GetComponent<Spot>().towerPlaced = newTower;
                gameManager.Money -= towers[tower].GetComponent<TowerData>().levels[0].cost;  //set the property which sets the actaul variable
         

            }         
        

        }
        else
        {
            Debug.Log("A tower has been placed!" + selectedTower.GetComponent<Spot>().towerPlaced);
        }

    }   


}
