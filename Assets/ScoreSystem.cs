using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    string scoreKey = "Score";
    public int CurrentScore { get; private set; }
    
    private void Awake() {
        CurrentScore = PlayerPrefs.GetInt(scoreKey);
    }

    public void SetScore(int Score){
        PlayerPrefs.SetInt(scoreKey, Score);
    }
}
