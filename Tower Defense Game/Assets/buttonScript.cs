using UnityEngine;
using System.Collections;


public class buttonScript : MonoBehaviour {

    public GameObject[] towers; //set up array of tower ooptions
    public GameObject selectedTower; //assign the clicked gameobject

    //public Spot spotScript; //do this to access t he clicked object script
    public GameObject towerPlaced;

    public void Update()
    {

        
    }


    public bool canPlaceTower()
    {
        towerPlaced = selectedTower.GetComponent<Spot>().towerPlaced; //check to see if a tower is  on thew open spot

        //int cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
        return towerPlaced == null; // && gameManager.Gold >= cost;
    }

    public void buildTower(int tower)
    {

        if (canPlaceTower())
        {
            //towerPlaced = (GameObject)
              GameObject newTower = Instantiate(towers[tower], selectedTower.transform.position, Quaternion.identity) as GameObject;
            ///Set the tower type to whatever the player picks
            selectedTower.GetComponent<Spot>().towerPlaced = newTower;

         }
        else
        {
            Debug.Log("A tower has been placed!" + selectedTower.GetComponent<Spot>().towerPlaced);
        }

    }   


}
