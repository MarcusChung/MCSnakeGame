using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isGameOver { get; private set; } = false;
    // public int score { get; private set; } = 0;
    // ScoreSystem scoreSystem;
    [SerializeField] private FloatSO scoreSO;
    [SerializeField] private PlayerProfileSO playerProfileSO;

    private const int LEVEL_SCORE_INCREMENT = 2;
    private Level currentLevel;
    private int currentProfile;
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
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
            PlayerPrefs.SetInt("ProfileDeaths:" + playerProfileSO.CurrentProfile, playerProfileSO.NumOfDeaths);
            PlayerPrefs.Save();
        }
        else
        {
            // FindObjectOfType<DeathScreen>().HideDeathScreen();
        }
    }
    private enum Level
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
    public void GameWon()
    {
        FindObjectOfType<Snake>().HideSnakeHead();

        playerProfileSO.LevelsComplete[(int)playerProfileSO.CurrentLevel - 1] = true;

        // Save the levels completed array
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            //playerProfileSO.LevelsComplete[i] returns a boolean value. 1 = true, 0 = false
            PlayerPrefs.SetInt("Profile: " + playerProfileSO.CurrentProfile + ":Level" + (i + 1), playerProfileSO.LevelsComplete[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
        Debug.Log("Game Won " + playerProfileSO.LevelsComplete[(int)playerProfileSO.CurrentLevel - 1]);
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
        PlayerPrefs.SetInt("TotalFruitAte: " + playerProfileSO.CurrentProfile, PlayerPrefs.GetInt("TotalFruitAte: " + playerProfileSO.CurrentProfile, 0) + 1);
        PlayerPrefs.Save();
    }
    public bool CheckScore(int score)
    {
        currentLevel = (Level)SceneManager.GetActiveScene().buildIndex;
        playerProfileSO.CurrentLevel = (PlayerProfileSO.Level)currentLevel;

        int targetScore = (int)currentLevel * LEVEL_SCORE_INCREMENT;
        Debug.Log("Target Score: " + targetScore);
        scoreSO.Value = score;
        LastScore = score;
        //if the score matches the target to win the level
        if (score >= targetScore)
        {
            GameWon();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SelectProfile(int profileNum)
    {
        currentProfile = profileNum;
        playerProfileSO.CurrentProfile = profileNum;
        playerProfileSO.NumOfDeaths = PlayerPrefs.GetInt("ProfileDeaths:" + profileNum, 0);
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            playerProfileSO.LevelsComplete[i] = PlayerPrefs.GetInt(
                "Profile: " + profileNum + ":Level" + (i + 1), 0
                ) == 1 ? true : false;
        }
    }

    public string ProfileDetails(int profileNum)
    {
        int numOfLevelsComplete = 0;
        string profileDetails = "Total number of deaths: " + PlayerPrefs.GetInt("ProfileDeaths:" + profileNum, 0) + "\n";
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            if (PlayerPrefs.GetInt("Profile: " + profileNum + ":Level" + (i + 1), 0) == 1)
            {
                numOfLevelsComplete++;
            }

            profileDetails += "Level " + (i + 1) + ": " + (PlayerPrefs.GetInt(
                "Profile: " + profileNum + ":Level" + (i + 1), 0
                ) == 1 ? "Complete" : "Incomplete") + "\n";
        }
        profileDetails += "Levels Complete: " + numOfLevelsComplete + " / " + playerProfileSO.LevelsComplete.Length + "\n";
        profileDetails += "Total Fruit Ate: " + PlayerPrefs.GetInt("TotalFruitAte: " + profileNum, 0) + "\n";
        return profileDetails;
    }
}
