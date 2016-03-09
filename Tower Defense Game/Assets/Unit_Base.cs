using UnityEngine;
using System.Collections;

public class Unit_Base : MonoBehaviour {

    public int health;
    public int victoryPoints;  //amount deducted from player when the creep reaches the end
    public int bounty;   //amount of points the player gets when destroyed

    public float speed;
    public float dropRate;
    public GameObject lootDrop;

    public GameManager gameManager;  //Find the game manager class



    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
   
     }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            Destroy(other.gameObject);
            if(health > 0)
            {
                health -= 10;
                gameManager.Money += bounty; 
                Debug.Log("ouch");
            }
            else
            {
                Destroy(gameObject);
            }        
            
        }
        

    }

}
