    using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Unit_Base : MonoBehaviour {

    //get the way points
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    public int health;
    public float armor;
    public enum ResistanceType { Fire, Energy} //May code more of these
    public int victoryPoints;  //amount deducted from player when the creep reaches the end
    public int bounty;   //amount of points the player gets when destroyed

   
    public float dropRate;
    public GameObject lootDrop;
    
    public GameManager gameManager;  //Find the game manager class


    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lastWaypointSwitchTime = Time.time; //Puts enemy waypoint switch time at current time
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Projectile"))
        {
            int damage = other.gameObject.GetComponent<BulletBehavior>().damage;
            Destroy(other.gameObject);

            Transform healthBarTransform = gameObject.transform.FindChild("HealthBar");
            HealthBar healthBar =
                healthBarTransform.gameObject.GetComponent<HealthBar>();
            healthBar.currentHealth -= Mathf.Max(damage, 0);

            if (health > 0)
            {
                health -= damage;
                Debug.Log("ouch");
            }
            else
            {
                Destroy(gameObject);
                gameManager.Money += bounty;
            }        
            
        }
    }

    public float distanceToGoal()
    {
        float distance = 0;
        distance += Vector3.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector3.Distance(startPosition, endPosition);
        }
        return distance;
    }


    public void Update()
    {

     
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        // 
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        
        // 3 
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                // 3.a 
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                // TODO: Rotate into move direction
            }
            else {
                Destroy(gameObject);

                //Audio here
                
                //deduct health
                gameManager.Health -= 1;
            }
        }

    }

}
