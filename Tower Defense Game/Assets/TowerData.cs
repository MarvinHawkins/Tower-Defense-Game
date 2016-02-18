using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class TowerLevel
{
    //Stores class and other info
    public int cost;
    public GameObject visualization;
    public GameObject projectile; //The projectile type used by the 
}

public class TowerData : MonoBehaviour {

    public List<TowerLevel> levels;
    private TowerLevel currentLevel;

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public TowerLevel CurrentLevel
    {
        //2
        get
        {
            return currentLevel;
        }
        //3
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
