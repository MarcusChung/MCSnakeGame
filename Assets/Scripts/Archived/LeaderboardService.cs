using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardService : MonoBehaviour
{
    private ILeaderboards abstractLeaderboard;

    private void Awake()
    {
        abstractLeaderboard = GetComponent<ILeaderboards>();
    }

    public bool SubmitScore(int score)
    {
        return abstractLeaderboard.SubmitScore(score);
    }

    public string GetLeaderboard()
    {
        return abstractLeaderboard.GetLeaderboard();
    }
}