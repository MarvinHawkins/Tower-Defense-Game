using UnityEngine;
using System.Collections;

public class LeaderBoard : MonoBehaviour
{

    public int[] highScores = new int[5];
    string highScoreKey = "";

    void Start()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScoreKey = "HighScore" + (i + 1).ToString();
            highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
            //use these values in whatever shows the leaderboard(s).
        }

    }
}