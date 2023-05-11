using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAchievementSys : IAchievement
{
    public event Action<string> OnAchievementUnlocked;

    public void UnlockAchievement(int achievementNum, string achievementName)
    {
        if(!HasAchievement(achievementNum))
        {
            GameManager.Instance.playerProfileSO.UnlockedAchievements[achievementNum] = achievementName;
            OnAchievementUnlocked?.Invoke(achievementName);
            Debug.Log("Achievement unlocked!!!: " + achievementName);
        }
    }

    public bool HasAchievement(int achievementNum)
    {
        if (GameManager.Instance.playerProfileSO.UnlockedAchievements[achievementNum] == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}