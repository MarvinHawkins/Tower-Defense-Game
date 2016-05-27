using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave
{
    public GameObject[] enemyPrefab;
    public GameObject[] waypoints;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour {

    
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    public GameManager gameManager;  //Find the game manager class
    // Use this for initialization
    void Start ()
    {
        lastSpawnTime = Time.time;
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {

           int currentWave = gameManager.Wave;
                //Check to make sure enemies are left
            if (currentWave < waves.Length)
            {
                // 2
                float timeInterval = Time.time - lastSpawnTime;
                float spawnInterval = waves[currentWave].spawnInterval;
                if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                     timeInterval > spawnInterval) &&
                    enemiesSpawned < waves[currentWave].maxEnemies)
                {
              
                lastSpawnTime = Time.time;
                  Vector3 startPos = GameObject.Find("Waypoint0").GetComponent<Transform>().position;  //Get the position of the first spawn point in the level
                            
                  GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab[Random.Range(0,waves[currentWave].enemyPrefab.Length)], startPos, Quaternion.identity); //Spawn a random enemy
                  newEnemy.GetComponent<Unit_Base>().waypoints = waves[currentWave].waypoints;
                  enemiesSpawned++;

            }
                // Check to see if the last enemeis have been spawned in current wave
                //If they have,  
                if (enemiesSpawned == waves[currentWave].maxEnemies &&
                    GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    gameManager.Wave++; //increase to wave
                   //gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                    enemiesSpawned = 0;
                    lastSpawnTime = Time.time;
                }

        }   else{
            //If no more enemies, and player still has lives call the win function load next level
            gameManager.gameOver = true;
        }


        }
	
	
}
