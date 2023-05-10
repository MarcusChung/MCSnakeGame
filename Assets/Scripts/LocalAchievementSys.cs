using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class LocalAchievementSys : IAchievement
// {
//     private Dictionary<string, bool> unlockedAchievements = new Dictionary<string, bool>();
//     public event Action<string> OnAchievementUnlocked;
//     private DataManager dataManager;
//     public void UnlockAchievement(string achievementName)
//     {

//         if (!unlockedAchievements.ContainsKey(achievementName))
//         {
//             unlockedAchievements[achievementName] = true;
//             OnAchievementUnlocked?.Invoke(achievementName);
//             // Debug.Log("Achievement unlocked: " + achievementName);
//         }
//     }

//     public void IncrementAchievement(string achievementName, int steps)
//     {
//         Debug.Log("Achievement unlocked: " + achievementName + " " + steps);
//     }

//     public bool HasAchievement(string achievementName)
//     {
//         return unlockedAchievements.ContainsKey(achievementName);
//     }
// }

public class LocalAchievementSys : IAchievement
{
    private Dictionary<string, bool> unlockedAchievements = new Dictionary<string, bool>();
    public event Action<string> OnAchievementUnlocked;
    private DataManager dataManager;

    public LocalAchievementSys(DataManager dataManager)
    {
        this.dataManager = dataManager;
        LoadAchievements();
    }

    public void UnlockAchievement(string achievementName)
    {
        if (!unlockedAchievements.ContainsKey(achievementName))
        {
            unlockedAchievements[achievementName] = true;
            OnAchievementUnlocked?.Invoke(achievementName);
            dataManager.SaveAchievement(achievementName, true);
        }
    }

    public bool HasAchievement(string achievementName)
    {
        return unlockedAchievements.ContainsKey(achievementName);
    }

    private void LoadAchievements()
    {
        Dictionary<string, bool> savedAchievements = dataManager.LoadAchievements();
        if (savedAchievements != null)
        {
            unlockedAchievements = savedAchievements;
        }
    }
}