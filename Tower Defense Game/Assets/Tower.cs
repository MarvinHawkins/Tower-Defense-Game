using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tower : MonoBehaviour {
    public buttonScript ButtonScript;
    public GameObject canvaStatsPanel;
    public TowerManager towerManager;
    public Transform selectionCircle;


    public bool isSelected;
    public Text statsLabel;
    // public Button[] upgradeButton;
    
    public Text upgradeLabel;



    void Start()
    {   //set the class objects

        ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
        canvaStatsPanel = ButtonScript.statPanel; //Should send this unit's stats to the panel

       statsLabel = canvaStatsPanel.GetComponentInChildren<Text>();
       //upgradeButton = canvaStatsPanel.GetComponentsInChildren<Button>();

       // upgradeButton = canvaStatsPanel.GetComponentInChildren<Button>();
       // upgradeLabel = upgradeButton.GetComponentInChildren<Text>();


        towerManager = GameObject.FindGameObjectWithTag("PlayerTowerManager").GetComponent<TowerManager>();
        selectionCircle = transform.Find("selectPlane");
        selectionCircle.gameObject.SetActive(false);
     }



    void OnMouseUp()
    {
 
        towerManager.selectSingleTower(gameObject);
        isSelected = true;
        ButtonScript.selectedTower = this.gameObject;
        ButtonScript.currentSpot = gameObject.GetComponentInParent<Spot>().transform;


        //set the tower to be the clicked object



        //tower stat manipulation stuff stuff
        //When the  tower is selected, show its stats 

        for (int i = 0; i < ButtonScript.upgradeButton.Length; i++)
        {
       
            upgradeLabel.GetComponent<Text>().text = "Upgrade Cost  " + gameObject.GetComponent<TowerData>().upgradeRate;

        }

        statsLabel.GetComponent<Text>().text= "Upgrade Cost  " + gameObject.GetComponent<TowerData>().upgradeRate;
      

        //To do need to figure out how to grab specific child
    }

    void Update()

    {

        if (isSelected == true)
        {
            selectionCircle.gameObject.SetActive(true);
            canvaStatsPanel.SetActive(true);
        }
        else if (isSelected == false)
        {
            selectionCircle.gameObject.SetActive(false);
            canvaStatsPanel.SetActive(false);
        }

    }





}
