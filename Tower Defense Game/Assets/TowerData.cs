using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]


public class TowerData : MonoBehaviour {

    //Stores class and other info
    public string towerName;
    public int cost;
    public float range; //how far casn the tower see?
    public float timeSinceLastShot;
    public float fireRate;
    public int sellRate;  //Controls how much money the player getss at each level
    public int upgradeRate; //Cost of the upgrade
    public GameObject projectile; //The projectile type used by the 
    public GameObject myUpgrade;



}
