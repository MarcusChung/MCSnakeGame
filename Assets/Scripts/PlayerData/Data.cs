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
    private Dictionary<string, bool> unlockedAchievements = new Dictionary<string, bool>();
    public string highScore;
    
    public Data()
    {
        deathCount = 0;
        fruitAte = 0;
        levelsCompleted = new bool[NUM_LEVELS];
        highScore = "0";
        unlockedAchievements = new Dictionary<string, bool>();
    }
}
