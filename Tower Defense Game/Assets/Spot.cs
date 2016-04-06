using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spot : MonoBehaviour {

    //Class Objects
    /*****************************************************/
    public buttonScript ButtonScript;
    public GameObject buildPanel; //the build pqanel
    public GameObject[] towers;  // public GameObject[] towers; //Array of game objects
    public GameObject towerPlaced; //Placeholder
    public TowerManager towerManager;
    public bool isSelected;  // class objects

    void Start()
        {   //set the class objects
             ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
            towerManager = GameObject.FindGameObjectWithTag("PlayerTowerManager").GetComponent<TowerManager>();
    }

    
    void OnMouseUp()
        {
            //Check to see if you can place a tower
            Debug.Log("spot  cicked");

        //Close the stats panel
        ButtonScript.statPanel.SetActive(false);
        towerManager.DeselectAll();


        ButtonScript.buildOptionsPanel.SetActive(true);
        ButtonScript.selectedTower = this.gameObject; //set the tower to be the clicked object



            
    } 

}