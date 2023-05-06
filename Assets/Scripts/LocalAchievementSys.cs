using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAchievementSys : IAchievement
{
    private Dictionary<string, bool> unlockedAchievements = new Dictionary<string, bool>();
    public event Action<string> OnAchievementUnlocked;
    public void UnlockAchievement(string achievementName)
    {

        if (!unlockedAchievements.ContainsKey(achievementName))
        {
            unlockedAchievements[achievementName] = true;
            OnAchievementUnlocked?.Invoke(achievementName);
            Debug.Log("Achievement unlocked: " + achievementName);
        }
    }

    public void IncrementAchievement(string achievementName, int steps)
    {
        Debug.Log("Achievement unlocked: " + achievementName + " " + steps);
    }

    public bool HasAchievement(string achievementName)
    {
        if (unlockedAchievements.ContainsKey(achievementName))
        {
            return unlockedAchievements[achievementName];
        }
        else
        {
            return false;
        }
    }
}