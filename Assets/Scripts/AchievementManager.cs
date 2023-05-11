using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementPanel achievementPanel;
    private static AchievementManager instance;
    private int currentProfile;
    private const int FULL_HP = 5;
    private const int LEVEL_ONE = 1;
    private const int LEVEL_TWO = 2;
    private const int LEVEL_THREE = 3;
    private const int LEVEL_FOUR = 4;
    private const int LEVEL_FIVE = 5;
    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("AchievementManager is null");
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ServiceLocator.AchievementSystem.OnAchievementUnlocked += OnAchievementUnlocked;
    }


    private void OnAchievementUnlocked(string achievementName)
    {
        if (GameManager.Instance != null && achievementPanel != null)
        {
            achievementPanel.ShowAchievement(achievementName);
            GameManager.Instance.StartCoroutine(HideAchievementPanel());
        }
    }
    private IEnumerator HideAchievementPanel()
    {
        yield return new WaitForSecondsRealtime(5f);
        achievementPanel.HideScreen();
    }

    public void CheckFruitAteAchievement(int totalFruitAte)
    {
        Debug.Log("total fruit ate check: " + totalFruitAte);
        switch (totalFruitAte)
        {
            case 5:
                ServiceLocator.AchievementSystem.UnlockAchievement(1, "Beginner- ate 5 fruits");
                break;
            case 15:
                ServiceLocator.AchievementSystem.UnlockAchievement(2, "Amateur- ate 15 fruits");
                break;
            case 30:
                ServiceLocator.AchievementSystem.UnlockAchievement(3, "Satiated- ate 30 fruits");
                break;
            case 50:
                ServiceLocator.AchievementSystem.UnlockAchievement(4, "Bloated- ate 50 fruits");
                break;
            case 100:
                ServiceLocator.AchievementSystem.UnlockAchievement(5, "Hungry- ate 100 fruits");
                break;
            case 250:
                ServiceLocator.AchievementSystem.UnlockAchievement(6, "Glutton- ate 250 fruits");
                break;
            case 500:
                break;
        }
    }
    public void CheckDeJaVuAchievement(int score, int lastGameScore)
    {
        if (score == lastGameScore)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(7, "De ja Vu- Got the same score as last game");
        }
    }
    
     public void CheckScoreAchievement(int score)
    {
        if (score == 1000)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(8, "Survivalist- Scored 100 points");
        } else if (score == 100)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(9, "YOU SCORED 1000 POINTS");
        }
    }
    //skipped 9.
    public void CheckFlawlessAchievement(int totalDeaths, int numOfLevelsComplete)
    {
        if (totalDeaths == 0 && numOfLevelsComplete == GameManager.Instance.playerProfileSO.LevelsComplete.Length)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(10, "Flawless- Completed all levels without dying once");
        }
    }

    public void NoDamageTakenAchievement(int hP, int level)
    {
        string achievementName = "No Damage Taken on level ";
        if (hP == FULL_HP && level == LEVEL_ONE)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(11, achievementName + level);
        }
        else if (hP == FULL_HP && level == LEVEL_TWO)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(12, achievementName + level);
        }
        else if (hP == FULL_HP && level == LEVEL_THREE)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(13, achievementName + level);
        }
        else if (hP == FULL_HP && level == LEVEL_FOUR)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(14, achievementName + level);
        }
        else if (hP == FULL_HP && level == LEVEL_FIVE)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(15, achievementName + level);
        }
    }

   
}
