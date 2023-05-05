using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardTest : MonoBehaviour
{
    void Start()
    {
        LeaderboardService lbs = FindObjectOfType<LeaderboardService>();

        if (lbs){
            string leaderboard = lbs.GetLeaderboard();
            Debug.Log(leaderboard);
        }
        else {
            //need to handle this case
        }
        
    }
}
