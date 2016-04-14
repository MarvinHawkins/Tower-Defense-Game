using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Tower : MonoBehaviour {
    public buttonScript ButtonScript;
    private TowerData towerData;
    public GameObject canvaStatsPanel;
    public TowerManager towerManager;
    public Transform selectionCircle;
    public bool isSelected;
    public Text statsLabel;
    public Text attackPowerLabel;
    public Text rofLabel;

    private float lastShotTime;
    public List<GameObject> enemiesInRange;
    public Transform muzzle;

    void Start()
    {   
        //set the class objects
        ButtonScript = GameObject.Find("Canvas/Panel").GetComponent<buttonScript>(); //get a refference to the buttonscript u=in scen
        canvaStatsPanel = ButtonScript.statPanel; //Should send this unit's stats to the panel
        statsLabel = canvaStatsPanel.GetComponentInChildren<Text>();


        towerManager = GameObject.FindGameObjectWithTag("PlayerTowerManager").GetComponent<TowerManager>();
        selectionCircle = transform.Find("selectPlane");
        selectionCircle.gameObject.SetActive(false);
        enemiesInRange = new List<GameObject>(); //Get alist of enemeies in range

        lastShotTime = Time.time;
        towerData = gameObject.GetComponentInChildren<TowerData>();

    }

    // Check for enemies in range
    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        // 2
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDelegateDestruction del =
                other.gameObject.GetComponent<EnemyDelegateDestruction>();
            del.enemyDelegate += OnEnemyDestroy;
          if (selectionCircle.gameObject.activeSelf)
          {
                selectionCircle.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
    // 3
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDelegateDestruction del =
                other.gameObject.GetComponent<EnemyDelegateDestruction>();
            del.enemyDelegate -= OnEnemyDestroy;

            if (selectionCircle.gameObject.activeSelf)
            {
                selectionCircle.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }

           
        }
    }

    
    void OnMouseUp()
    {

        //set the clicked to true
        // isSelected = true;
         towerManager.selectSingleTower(gameObject);
        //show the towers options
        canvaStatsPanel.SetActive(true);
        ButtonScript.buildOptionsPanel.SetActive(false);
        ButtonScript.selectedTower = this.gameObject;      
        ButtonScript.currentSpot = gameObject.GetComponentInParent<Spot>().transform;
        //Set the name of the selected tower
        statsLabel.GetComponent<Text>().text = "Tower: " + gameObject.GetComponent<TowerData>().towerName;


        ButtonScript.statLabels[1].GetComponentInChildren<Text>().text = "Attack Power: " + gameObject.GetComponent<TowerData>().projectile.GetComponent<BulletBehavior>().damage.ToString();
        ButtonScript.statLabels[2].GetComponentInChildren<Text>().text = "Rate of Fire: " + gameObject.GetComponent<TowerData>().rofList;
        //get text of each button in the array
        ButtonScript.upgradeButton[0].GetComponentInChildren<Text>().text = "Sell Tower: " + gameObject.GetComponent<TowerData>().sellRate;
        ButtonScript.upgradeButton[1].GetComponentInChildren<Text>().text = "Upgrade Tower: " + gameObject.GetComponent<TowerData>().upgradeRate;
  
    }

    void Shoot(Collider2D target)
    {

        //Alternate shoot
        GameObject bulletPrefab = towerData.projectile;
        // 1 
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;

        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
        
    }


    void Update()
    {
     
  if (towerManager.IsSelected(gameObject))
        {
            selectionCircle.gameObject.SetActive(true);

        }
        else
        {
        
            selectionCircle.gameObject.SetActive(false);

        }


        //Shooting Stuff

        GameObject target = null;
        // 1
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<Unit_Base>().distanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // 2
        if (target != null)
        {
            if (Time.time - lastShotTime > towerData.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
            // 3
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
                new Vector3(0, 0, 1));
        }

    }

}