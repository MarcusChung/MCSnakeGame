using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAchievement
{
    void UnlockAchievement(string achievementName);
    void IncrementAchievement(string achievementName, int steps);
    event Action<string> OnAchievementUnlocked;
    bool HasAchievement(string achievementName);
}