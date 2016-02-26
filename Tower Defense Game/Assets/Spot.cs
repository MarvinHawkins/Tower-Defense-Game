using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spot : MonoBehaviour {

    //Class Objects
    /*****************************************************/
    public buttonScript ButtonScript;

    public GameObject buildPanel; //the build pqanel
    public GameObject[] towers;                              // public GameObject[] towers; //Array of game objects
    public GameObject towerPlaced; //Placeholder
    public bool isSelected;                               // class objects


    void Start()
    {   //set the class objects
        
        ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
    }

    public void buildTower(int tower)
    {
        
        GameObject newTower = Instantiate(towers[tower], transform.position, Quaternion.identity) as GameObject;
    }

    
    

    //Check to see if you can place a tower

     
    void OnMouseUp()
    {
        //if (towerPlaced == null)
        Debug.Log("spot  cicked");
        ButtonScript.selectedTower = this.gameObject; //set the tower to be the clicked object
                                                          //ButtonScript.towerPlaced = towerPlaced;
        
       

    } 




}
