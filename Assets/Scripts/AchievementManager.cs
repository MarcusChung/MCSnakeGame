using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementPanel achievementPanel;
    private static AchievementManager instance;
    private int currentProfile;
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
        // FindObjectOfType<DataPersistenceManager>().LoadGame(GameManager.Instance.currentProfile.ToString());
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
            case int n when n >= 5:
                ServiceLocator.AchievementSystem.UnlockAchievement(1, "Beginner");
                break;
            case int n when n >= 15:
                ServiceLocator.AchievementSystem.UnlockAchievement(2, "Amateur");
                break;
            case int n when n >= 30:
                ServiceLocator.AchievementSystem.UnlockAchievement(3, "Satiated");
                break;
            case int n when n >= 100:
                ServiceLocator.AchievementSystem.UnlockAchievement(4, "Hungry");
                break;
            case int n when n >= 250:
                ServiceLocator.AchievementSystem.UnlockAchievement(5, "Glutton");
                break;
            case int n when n >= 500:
                ServiceLocator.AchievementSystem.UnlockAchievement(6, "Ravenous");
                break;
        }
    }

    public void CheckGameWonAchievements(int totalDeaths, int numOfLevelsComplete)
    {
        //checks if the player has completed all levels without dying
        // if (PlayerPrefs.GetInt("ProfileDeaths:" + currentProfile, 0) == 0 && numOfLevelsComplete == numOfLevels)
        // {
        //     ServiceLocator.AchievementSystem.UnlockAchievement("Flawless");
        // }

        if (totalDeaths == 0 && numOfLevelsComplete == GameManager.Instance.playerProfileSO.LevelsComplete.Length)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(10, "Flawless");
        }
    }

    public int CheckScoreAchievement(int score)
    {
        if (score >= 2)
        {
            // Debug.Log("score achievement: " + score);
            ServiceLocator.AchievementSystem.UnlockAchievement(6, "YOU SCORED 2 POINTS");
        }
        return score;
    }
    public void CheckDeJaVuAchievement(int score, int lastGameScore)
    {
        if (score == lastGameScore)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement(7, "Deja Vu");
        }
    }
}
