using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private static IAchievement achievementSystem;

    public static IAchievement AchievementSystem
    {
        get
        {
            if (achievementSystem == null)
            {
                achievementSystem = new LocalAchievementSystem();
            }
            return achievementSystem;
        }
        set
        {
            achievementSystem = value;
        }
    }
}