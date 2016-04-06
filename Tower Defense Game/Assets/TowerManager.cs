using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour {

    public List<GameObject> selectedTowers;     

	// Use this for initialization
	void Start () {

        selectedTowers.Clear();
	}

    //Control which tower is selected
    public bool IsSelected(GameObject tower)
    {
        if (selectedTowers.Contains(tower))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void selectSingleTower( GameObject towerClicked)
    {
        selectedTowers.Clear(); //Clear the current list
        selectedTowers.Add(towerClicked);
        
    }

    public void DeselectAll()
    {
        selectedTowers.Clear();

    }

	
}
