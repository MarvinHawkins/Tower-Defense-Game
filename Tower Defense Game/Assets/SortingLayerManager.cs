using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum SortingLayers { play, ground, Default }
public class SortingLayerManager : MonoBehaviour {
    private static Dictionary<string, int> SortingLayers = new Dictionary<string, int>(10);

    void OnEnable()
    {
        SortingLayers.Add("play", 0);
        SortingLayers.Add("ground", 1);
        SortingLayers.Add("Default", 2);
      
    }

    private static int Compare(GameObject gameObject1, GameObject gameObject2)
    {
        string layer1 = gameObject1.GetComponent<Renderer>().sortingLayerName,
               layer2 = gameObject1.GetComponent<Renderer>().sortingLayerName;

        if (SortingLayers[layer1].CompareTo(SortingLayers[layer2]) == 0)
        {
            return gameObject1.GetComponent<Renderer>().sortingOrder.CompareTo(gameObject2.GetComponent<Renderer>().sortingOrder);
        }

        return SortingLayers[layer1].CompareTo(SortingLayers[layer2]);
    }

    public static bool IsTopmost(GameObject go)
    {
        RaycastHit2D[] hits;
        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wp.z = Camera.main.transform.position.z;
        hits = Physics2D.RaycastAll(wp, Vector2.zero, Vector3.Distance(Camera.main.transform.position, go.transform.position) * 2);

        if (hits.Length == 0)
        {
            return false;
        }

        GameObject topMostSoFar = hits[0].collider.gameObject;

        RaycastHit2D hit;
        for (int i = 1; i < hits.Length; i++)
        {
            hit = hits[i];

            if (Compare(topMostSoFar, hit.collider.gameObject) == -1)
            {
                topMostSoFar = hit.collider.gameObject;
            }
        }

        return topMostSoFar == go;
    }
}
