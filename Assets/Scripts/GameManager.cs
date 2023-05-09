using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private DataManager dataManager;
    public bool isGameOver { get; private set; } = false;
    [SerializeField] private FloatSO scoreSO;
    [SerializeField] private PlayerProfileSO playerProfileSO;

    private const int LEVEL_SCORE_INCREMENT = 1;
    private Level currentLevel;
    public int currentProfile;
    private int EndlessModeLevel = 6;
    private int numOfLevelsComplete = 0;
    public int prevLevelScore;
    // [SerializeField] private AchievementPanel achievementPanel;
    //the last score the player got on that level
    public float LastScore
    {
        get
        {
            return PlayerPrefs.GetFloat("Score" + playerProfileSO.CurrentProfile + " " + playerProfileSO.CurrentLevel, 0f);
        }
        set
        {
            PlayerPrefs.SetFloat("Score" + playerProfileSO.CurrentProfile + " " + playerProfileSO.CurrentLevel, value);
            PlayerPrefs.Save();
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        dataManager = new DataManager();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // ServiceLocator.AchievementSystem.OnAchievementUnlocked += OnAchievementUnlocked;
        prevLevelScore = (int)LastScore;
        Debug.Log("build index " + SceneManager.GetActiveScene().buildIndex);
        dataManager.Load();
        // dataManager.ResetGameData();
        // dataManager.Save();
        ResetScore();
    }

    public void ResetScore()
    {
        scoreSO.Value = 0;
    }
    public void GameOver(bool flag)
    {
        isGameOver = flag;
        if (isGameOver == true)
        {
            playerProfileSO.NumOfDeaths++;
            dataManager.SetNumOfDeaths(playerProfileSO.NumOfDeaths, playerProfileSO.CurrentProfile);
            dataManager.Save();
        }
    }
    private enum Level
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
    public void ResetStats(int profileNum)
    {
        playerProfileSO.NumOfDeaths = 0;
        PlayerPrefs.SetInt("ProfileDeaths:" + profileNum, playerProfileSO.NumOfDeaths);
        PlayerPrefs.SetInt("TotalFruitAte: " + profileNum, 0);
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            playerProfileSO.LevelsComplete[i] = false;
            PlayerPrefs.SetInt("Profile: " + profileNum + ":Level" + (i + 1), 0);
        }
        PlayerPrefs.Save();
    }
    public void IncrementTotalNumOfFruitAte()
    {
        // PlayerPrefs.SetInt("TotalFruitAte: " + playerProfileSO.CurrentProfile, PlayerPrefs.GetInt("TotalFruitAte: " + playerProfileSO.CurrentProfile, 0) + 1);
        // PlayerPrefs.Save();
        dataManager.SetNumOfFruitAte(dataManager.GetNumOfFruitAte(playerProfileSO.CurrentProfile) + 1, playerProfileSO.CurrentProfile);
        dataManager.Save();
        AchievementManager.Instance.CheckFruitAteAchievement(playerProfileSO.CurrentProfile);
    }
    public bool CheckScore(int score)
    {
        currentLevel = (Level)SceneManager.GetActiveScene().buildIndex;
        playerProfileSO.CurrentLevel = (PlayerProfileSO.Level)currentLevel;

        int targetScore = (int)currentLevel * LEVEL_SCORE_INCREMENT;
        scoreSO.Value = score;
        LastScore = score;
        // SetLastScore(score, currentProfile, (int)currentLevel);
        AchievementManager.Instance.CheckScoreAchievement(score);
        AchievementManager.Instance.CheckDeJaVuAchievement(score, prevLevelScore);
        //if the score matches the target to win the level
        if (score >= targetScore && (int)currentLevel != EndlessModeLevel)
        {
            GameWon();
            return true;
        }
        else
        {
            return false;
        }
    }

    // public void SetLastScore(int score, int currentProfile, int currentLevel)
    // {
    //     dataManager.SetLastScore(score, currentProfile, currentLevel);
    //     dataManager.Save();
    // }
    // public int GetLastScore()
    // {
    //     // Debug.Log("GetLastScore " + dataManager.GetLastScore(playerProfileSO.CurrentProfile, (int) SceneManager.GetActiveScene().buildIndex));
    //     // Debug.Log("profile num" + playerProfileSO.CurrentProfile);
    //     Debug.Log("current profile" + currentProfile);
    //     return dataManager.GetLastScore(currentProfile, (int)SceneManager.GetActiveScene().buildIndex);
    //     // SceneManager.GetActiveScene().buildIndex
    // }

    public void GameWon()
    {
        numOfLevelsComplete = 0;
        FindObjectOfType<Snake>().HideSnakeHead();

        playerProfileSO.LevelsComplete[(int)playerProfileSO.CurrentLevel - 1] = true;

        bool[] levelsComplete = dataManager.GetLevelsComplete(playerProfileSO.CurrentProfile);
        levelsComplete[(int)playerProfileSO.CurrentLevel - 1] = true;
        // dataManager.SetNumOfLevelsComplete(dataManager.GetNumOfLevelsComplete(playerProfileSO.CurrentProfile) + 1, playerProfileSO.CurrentProfile);
        dataManager.SetLevelsComplete(levelsComplete, playerProfileSO.CurrentProfile);
        dataManager.Save();

         for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            PlayerPrefs.SetInt("Profile: " + playerProfileSO.CurrentProfile + ":Level" + (i + 1), playerProfileSO.LevelsComplete[i] ? 1 : 0);
            //counts the num of levels complete
            numOfLevelsComplete = playerProfileSO.LevelsComplete.Count(l => l);
        }
        PlayerPrefs.Save();
        
        AchievementManager.Instance.CheckFlawlessAchievement(playerProfileSO.CurrentProfile, numOfLevelsComplete, playerProfileSO.LevelsComplete.Length);
    }

    public void SelectProfile(int profileNum)
    {
        currentProfile = profileNum;
        playerProfileSO.CurrentProfile = profileNum;
        // playerProfileSO.NumOfDeaths = PlayerPrefs.GetInt("ProfileDeaths:" + profileNum, 0);
        playerProfileSO.NumOfDeaths = dataManager.GetGameData().totalDeaths[profileNum];
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            playerProfileSO.LevelsComplete[i] = PlayerPrefs.GetInt(
                "Profile: " + profileNum + ":Level" + (i + 1), 0
                ) == 1 ? true : false;
        }
    }

    // public string ProfileDetails(int profileNum)
    // {
    //     numOfLevelsComplete = 0;
    //     // int totalNumOfDeaths = PlayerPrefs.GetInt("ProfileDeaths:" + profileNum, 0);
    //     int totalNumOfDeaths = dataManager.GetTotalDeaths(profileNum);
    //     string profileDetails = "Total number of deaths: " + totalNumOfDeaths + "\n";

    //     for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
    //     {
    //         if (dataManager.GetLevelsComplete(profileNum)[i])
    //         {
    //             numOfLevelsComplete++;
    //         }
    //         profileDetails += "Level " + (i + 1) + ": " + (dataManager.GetLevelsComplete(profileNum)[i] ? "Complete" : "Incomplete") + "\n";
    //         // Debug.Log("Level " + (i + 1) + ": " + (dataManager.GetLevelsComplete(profileNum)[i] ? "Complete" : "Incomplete") + profileNum +"\n");
    //     }

    //     profileDetails += "Levels Complete: " + numOfLevelsComplete + " / " + playerProfileSO.LevelsComplete.Length + "\n";
    //     // profileDetails += "Levels Complete: " + dataManager.GetNumOfLevelsComplete(profileNum) + " / " + playerProfileSO.LevelsComplete.Length + "\n";
    //     profileDetails += "Total Fruit Ate: " + dataManager.GetNumOfFruitAte(profileNum) + "\n";
    //     return profileDetails;
    // }

    public string ProfileDetails(int profileNum)
    {
        numOfLevelsComplete = 0;
        int totalNumOfDeaths = PlayerPrefs.GetInt("ProfileDeaths:" + profileNum, 0);
        string profileDetails = "Total number of deaths: " + totalNumOfDeaths + "\n";
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            if (PlayerPrefs.GetInt("Profile: " + profileNum + ":Level" + (i + 1), 0) == 1)
            {
                numOfLevelsComplete++;
            }
            profileDetails += "Level " + (i + 1) + ": " + (PlayerPrefs.GetInt("Profile: " + profileNum + ":Level" + (i + 1), 0) == 1 ? "Complete" : "Incomplete") + "\n";
        }
        profileDetails += "Levels Complete: " + numOfLevelsComplete + " / " + playerProfileSO.LevelsComplete.Length + "\n";
        profileDetails += "Total Fruit Ate: " + dataManager.GetNumOfFruitAte(profileNum) + "\n";
        return profileDetails;
    }

    private void OnApplicationQuit()
    {
        dataManager.Save();
    }
}
