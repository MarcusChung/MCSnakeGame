using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAchievement
{
    void UnlockAchievement(int achievementNum, string achievementName);
    // void IncrementAchievement(string achievementName, int steps);
    event Action<string> OnAchievementUnlocked;
    bool HasAchievement(int achievementNum);
}