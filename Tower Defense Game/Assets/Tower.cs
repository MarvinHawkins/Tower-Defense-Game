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
    public Text labels;


  
    public string[] buttonLabels;



    void Start()
    {   //set the class objects

        ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
        canvaStatsPanel = ButtonScript.statPanel; //Should send this unit's stats to the panel
       statsLabel = canvaStatsPanel.GetComponentInChildren<Text>();
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

        statsLabel.GetComponent<Text>().text = "Tower: " + gameObject.GetComponent<TowerData>().towerName;

        //get text of each button in the array
        ButtonScript.upgradeButton[0].GetComponentInChildren<Text>().text = "Sell Tower: " + gameObject.GetComponent<TowerData>().sellRate;
        ButtonScript.upgradeButton[1].GetComponentInChildren<Text>().text = "Upgrade Tower: " + gameObject.GetComponent<TowerData>().upgradeRate;

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
