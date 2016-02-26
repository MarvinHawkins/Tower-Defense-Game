using UnityEngine;
using System.Collections;

public class DetectClick : MonoBehaviour {

  

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            

            Debug.Log("Object hit: " + hit.collider.gameObject.name);
        }



    }
}
