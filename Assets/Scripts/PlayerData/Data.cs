using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int deathCount;
    public int fruitAte;
    public bool[] levelsCompleted;
    private const int NUM_LEVELS = 5;
    public string[] unlockedAchievements;
    private const int MAX_ACHIEVEMENTS = 100;
    public string highScore;
    
    public Data()
    {
        deathCount = 0;
        fruitAte = 0;
        levelsCompleted = new bool[NUM_LEVELS];
        highScore = "0";
        unlockedAchievements = new string[MAX_ACHIEVEMENTS];
    }
}
