using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAchievement
{
    void UnlockAchievement(string achievementName);
    void IncrementAchievement(string achievementName, int steps);
}