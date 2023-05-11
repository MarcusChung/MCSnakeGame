using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Linq;

public class GameManager : MonoBehaviour, IDataPersistence
{
    private static GameManager instance;
    public bool isGameOver { get; private set; } = false;
    [SerializeField] private FloatSO scoreSO;
    [SerializeField] public PlayerProfileSO playerProfileSO;
    private const int LEVEL_SCORE_INCREMENT = 2;
    private Level currentLevel;
    public int currentProfile;
    private int EndlessModeLevel = 6;
    private int numOfLevelsComplete = 0;
    public int prevLevelScore;
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        prevLevelScore = (int)LastScore;
        // Debug.Log("build index " + SceneManager.GetActiveScene().buildIndex);
        ResetScore();
    }
    private void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    public void ResetScore()
    {
        scoreSO.Value = 0;
    }

    private enum Level
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
    public void IncrementTotalNumOfFruitAte()
    {
        playerProfileSO.FruitAte++;
    }
    public bool CheckScore(int score)
    {
        currentLevel = (Level)SceneManager.GetActiveScene().buildIndex;
        playerProfileSO.CurrentLevel = (PlayerProfileSO.Level)currentLevel;

        int targetScore = (int)currentLevel * LEVEL_SCORE_INCREMENT;
        scoreSO.Value = score;
        LastScore = score;
        AchievementManager.Instance.CheckFruitAteAchievement(playerProfileSO.FruitAte);
        AchievementManager.Instance.CheckScoreAchievement(score);
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

    public void GameWon()
    {
        numOfLevelsComplete = 0;
        FindObjectOfType<Snake>().HideSnakeHead();

        playerProfileSO.LevelsComplete[(int)playerProfileSO.CurrentLevel - 1] = true;

        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            PlayerPrefs.SetInt("Profile: " + playerProfileSO.CurrentProfile + ":Level" + (i + 1), playerProfileSO.LevelsComplete[i] ? 1 : 0);
            //counts the num of levels complete
            numOfLevelsComplete = playerProfileSO.LevelsComplete.Count(l => l);
        }
        PlayerPrefs.Save();
        AchievementManager.Instance.NoDamageTakenAchievement(playerProfileSO.HP, (int)playerProfileSO.CurrentLevel);
        AchievementManager.Instance.CheckFlawlessAchievement(playerProfileSO.NumOfDeaths, numOfLevelsComplete);
    }

    public void GameOver(bool flag)
    {
        isGameOver = flag;
        if (isGameOver == true)
        {
            playerProfileSO.NumOfDeaths++;
        }
    }

    public void SelectProfile(int profileNum)
    {
        currentProfile = profileNum;
        playerProfileSO.CurrentProfile = profileNum;
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            playerProfileSO.LevelsComplete[i] = PlayerPrefs.GetInt(
                "Profile: " + profileNum + ":Level" + (i + 1), 0
                ) == 1 ? true : false;
        }
        FindObjectOfType<DataPersistenceManager>().LoadGame(profileNum.ToString());
    }

    public string ProfileDetails(int profileNum)
    {
        FindObjectOfType<DataPersistenceManager>().LoadGame(profileNum.ToString());
        numOfLevelsComplete = 0;
        int totalNumOfDeaths = playerProfileSO.NumOfDeaths;
        string profileDetails = "Total number of deaths: " + totalNumOfDeaths + "\n";
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            if (playerProfileSO.LevelsComplete[i])
            {
                numOfLevelsComplete++;
            }
            profileDetails += "Level " + (i + 1) + ": " + (playerProfileSO.LevelsComplete[i] ? "Complete" : "Incomplete") + "\n";
        }
        profileDetails += "Levels Complete: " + numOfLevelsComplete + " / " + playerProfileSO.LevelsComplete.Length + "\n";
        profileDetails += "Total Fruit Ate: " + playerProfileSO.FruitAte + "\n";
        profileDetails += "Survival Mode High Score: " + playerProfileSO.HighScore + "\n";
        return profileDetails;
    }
    public void LoadData(Data data)
    {
        playerProfileSO.NumOfDeaths = data.deathCount;
        playerProfileSO.FruitAte = data.fruitAte;
        playerProfileSO.LevelsComplete = data.levelsCompleted;
        playerProfileSO.HighScore = data.highScore;
        playerProfileSO.UnlockedAchievements = data.unlockedAchievements;
    }

    public void SaveData(ref Data data)
    {
        data.deathCount = playerProfileSO.NumOfDeaths;
        data.fruitAte = playerProfileSO.FruitAte;
        data.levelsCompleted = playerProfileSO.LevelsComplete;
        data.highScore = playerProfileSO.HighScore;
        data.unlockedAchievements = playerProfileSO.UnlockedAchievements;
    }

    //on application scene change, save game()
    private void ChangedActiveScene(Scene current, Scene next)
    {
        playerProfileSO.CurrentLevel = (PlayerProfileSO.Level)SceneManager.GetActiveScene().buildIndex;
    }
}
