using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAchievementSys : IAchievement, IDataPersistence
{
    private Dictionary<string, bool> unlockedAchievements = new Dictionary<string, bool>();
    public event Action<string> OnAchievementUnlocked;
    private DataManager dataManager;
    public void UnlockAchievement(string achievementName)
    {

        if (!unlockedAchievements.ContainsKey(achievementName))
        {
            unlockedAchievements[achievementName] = true;
            OnAchievementUnlocked?.Invoke(achievementName);
            // Debug.Log("Achievement unlocked: " + achievementName);
        }
    }

    public void IncrementAchievement(string achievementName, int steps)
    {
        Debug.Log("Achievement unlocked: " + achievementName + " " + steps);
    }

    public bool HasAchievement(string achievementName)
    {
        return unlockedAchievements.ContainsKey(achievementName);
    }

    public void LoadData(Data data)
    {
        throw new NotImplementedException();
    }

    public void SaveData(ref Data data)
    {
        throw new NotImplementedException();
    }
}

// public class LocalAchievementSys : IAchievement
// {
//     private Dictionary<string, bool> unlockedAchievements = new Dictionary<string, bool>();
//     public event Action<string> OnAchievementUnlocked;

//     public LocalAchievementSys()
//     {
//         LoadAchievements();
//     }

//     public void UnlockAchievement(string achievementName)
//     {
//         if (!unlockedAchievements.ContainsKey(achievementName))
//         {
//             unlockedAchievements[achievementName] = true;
//             OnAchievementUnlocked?.Invoke(achievementName);
//             // dataManager.SaveAchievement(achievementName, true);
//             // Debug.Log("Achievement unlocked: " + achievementName);
//         }
//     }

//     public bool HasAchievement(string achievementName)
//     {
//         return unlockedAchievements.ContainsKey(achievementName);
//     }

//     private void LoadAchievements()
//     {
//         // Dictionary<string, bool> savedAchievements = dataManager.LoadAchievements();
//         Dictionary<string, bool> savedAchievements = new Dictionary<string, bool>();
//         if (savedAchievements != null)
//         {
//             unlockedAchievements = savedAchievements;
//         }
//     }
// }