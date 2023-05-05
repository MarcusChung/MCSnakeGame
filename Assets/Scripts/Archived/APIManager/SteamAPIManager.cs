using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAPIManager : MonoBehaviour, ILeaderboards
{
    [SerializeField] private int appID;

    private void Awake()
    {
        // if (SteamManager.Initialized) {
        //     Debug.Log("Steamworks initialized!");
        // }
    }
    public string GetLeaderboard()
    {
        //some steam specific code
        return "leaderboard";
    }

    public bool SubmitScore(int score)
    {
        //some steam specific code

        return true;
    }
}