using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Spot : MonoBehaviour {

    //Class Objects
    /*****************************************************/
    public buttonScript ButtonScript;
    public GameObject buildPanel; //the build pqanel
    public GameObject[] towers;  // public GameObject[] towers; //Array of game objects
    public GameObject towerPlaced; //Placeholder
    public TowerManager towerManager;
    public bool isSelected;  // class objects
                             //Test to instantiate
    public GameObject buildCanvas;


    void Start()
            {   //set the class objects
                ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript in scen
                towerManager = GameObject.FindGameObjectWithTag("PlayerTowerManager").GetComponent<TowerManager>();
                buildCanvas.SetActive(false);
            }

    void OnMouseUp()
      {
        buildCanvas.SetActive(true);
        buildCanvas.GetComponentInChildren<Button>().onClick.AddListener(() => testButton());
        //GameObject button = (GameObject)Instantiate(buildCanvas);
        //button.GetComponentInChildren<Text>().text = "Marv";


        //Check  to see if you can place a tower
        Debug.Log("spot  clicked");

        //Close the stats panel
        ButtonScript.statPanel.SetActive(false);
        towerManager.DeselectAll();
        ButtonScript.buildOptionsPanel.SetActive(true);
        ButtonScript.selectedTower = this.gameObject; //set the tower to be the clicked object        
    } 

    void OnMouseOver()
    {
        Debug.Log("Hovering!");
        ButtonScript.tooltipPanel.SetActive(true);
     }

    //Test behavior
    void testButton()
    {
        Debug.Log("I work");
    }

}