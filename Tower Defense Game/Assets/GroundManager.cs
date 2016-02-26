using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {


    public TowerManager selectManager;
    public buttonScript ButtonScript;
    public GameObject canvaStatsPanel;


    // Use this for initialization
    void Start()
    {
        ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
        canvaStatsPanel = ButtonScript.statPanel;
        selectManager = GameObject.FindGameObjectWithTag("PlayerTowerManager").GetComponent<TowerManager>();
       

    }



    void OnMouseUp()
    {
        if(ButtonScript.selectedTower != null)
        {
            //Cannot click on ground unless something is clicked
            Debug.Log("Ground clicked");
            selectManager.DeselectAll();

        }
       
          

 

    //    canvaStatsPanel.SetActive(false);
      //  ButtonScript.selectedTower = this.gameObject; //set the tower to be the clicked object


    }

  
	
	// Update is called once per frame
	void Update () {
	
	}
}
