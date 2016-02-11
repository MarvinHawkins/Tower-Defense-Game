using UnityEngine;
using System.Collections;


public class buttonScript : MonoBehaviour {

    public GameObject[] Towers; //Create an array of t he towers available to the player

	public void buildTower(int tower){

        GameObject newTower = Instantiate(Towers[tower]);

    }
}
