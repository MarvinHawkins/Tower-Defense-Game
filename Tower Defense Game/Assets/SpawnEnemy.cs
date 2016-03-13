using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;

    public Wave[] waves;
    public int timeBetweenWaves = 5;

    public GameManager gameManager;  //Find the game manager class

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    // Use this for initialization
    void Start () {
       // Instantiate(testEnemyPrefab).GetComponent<Unit_Base>().waypoints = waypoints;
        lastSpawnTime = Time.time;

        gameManager =
    GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    public void Update()
    {

        // 1
        int currentWave = gameManager.Wave;
        //Check to make sure waves are left
            if (currentWave < waves.Length)
            {
                // 2
                float timeInterval = Time.time - lastSpawnTime;
                float spawnInterval = waves[currentWave].spawnInterval;
                if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                     timeInterval > spawnInterval) &&
                    enemiesSpawned < waves[currentWave].maxEnemies)
                {
                    // 3  
                    lastSpawnTime = Time.time;
                    GameObject newEnemy = (GameObject)
                        Instantiate(waves[currentWave].enemyPrefab);
                    newEnemy.GetComponent<Unit_Base>().waypoints = waypoints;
                    enemiesSpawned++;
                }
                // Check to see if the last enemeis have been spawned in current wave
                //If they have,  
                if (enemiesSpawned == waves[currentWave].maxEnemies &&
                    GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    gameManager.Wave++;
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
