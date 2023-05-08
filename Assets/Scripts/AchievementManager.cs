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
        ServiceLocator.AchievementSystem.OnAchievementUnlocked += OnAchievementUnlocked;
    }

    private void Update()
    {
        // if (GameManager.Instance.currentProfile != 0)
        // {
        //     currentProfile = GameManager.Instance.currentProfile;
        // }
    }


    private void OnAchievementUnlocked(string achievementName)
    {
        if (GameManager.Instance != null && achievementPanel != null)
        {
            achievementPanel.ShowAchievement(achievementName);
            // GameManager.Instance.StartCoroutine(HideAchievementPanel());
        }
    }
    private IEnumerator HideAchievementPanel()
    {
        yield return new WaitForSecondsRealtime(5f);
        achievementPanel.HideScreen();
    }

    public void CheckFruitAteAchievement(int currentProfile)
    {
        if (PlayerPrefs.GetInt("TotalFruitAte: " + currentProfile, 0) >= 5 && !ServiceLocator.AchievementSystem.HasAchievement("Novice_eater"))
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("Novice_eater");
        }
        else if (PlayerPrefs.GetInt("TotalFruitAte: " + currentProfile, 0) >= 100 && !ServiceLocator.AchievementSystem.HasAchievement("Glutton"))
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("Glutton");
        }
        else if (PlayerPrefs.GetInt("TotalFruitAte: " + currentProfile, 0) >= 250)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("Hungry");
        }
        else if (PlayerPrefs.GetInt("TotalFruitAte: " + currentProfile, 0) >= 500)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("Ravenous");
        }
    }
    
    public void CheckFlawlessAchievement(int currentProfile, int numOfLevelsComplete, int numOfLevels){
        //checks if the player has completed all levels without dying
        if (PlayerPrefs.GetInt("ProfileDeaths:" + currentProfile, 0) == 0 && numOfLevelsComplete == numOfLevels)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("Flawless");
        }
    }

    public int CheckScoreAchievement(int score)
    {
        if (score >= 2)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("YOU SCORED 2 POINTS");
        }
        return score;
    }
    public void CheckDeJaVuAchievement(int score, int lastGameScore)
    {
        if (score == lastGameScore)
        {
            ServiceLocator.AchievementSystem.UnlockAchievement("Deja Vu");
        }
    }
}