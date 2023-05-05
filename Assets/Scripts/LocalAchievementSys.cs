using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAchievementSystem : IAchievement
{
    public void UnlockAchievement(string achievementName)
    {
        Debug.Log("Achievement unlocked: " + achievementName);
        if (achievementName == "Achievement1")
        {
            Debug.Log("completed in first try");
        }
        if (achievementName == "Flawless")
        {
            Debug.Log("completed without dying");
        }
        if (achievementName == "Glutton")
        {
            Debug.Log("ate all the food");
        }
        if (achievementName == "Ravenous")
        {
            Debug.Log("endless appetite");
        }
    }

    public void IncrementAchievement(string achievementName, int steps)
    {
        // Code to increment the specified achievement locally
        Debug.Log("Achievement unlocked: " + achievementName + " " + steps);
    }

    
}