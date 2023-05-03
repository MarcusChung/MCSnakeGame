using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameOver { get; private set; } = false;
    // public int score { get; private set; } = 0;
    // ScoreSystem scoreSystem;
    [SerializeField] private FloatSO scoreSO;
    [SerializeField] private PlayerProfileSO playerProfileSO;

    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private GameObject winScreenUI;
    private const int LEVEL_SCORE_INCREMENT = 5;
    private Level currentLevel;
    private int currentProfile;

    private void Start()
    {
        scoreSO.Value = 0;
        currentLevel = (Level)SceneManager.GetActiveScene().buildIndex;
        playerProfileSO.CurrentLevel = (PlayerProfileSO.Level)currentLevel;
    }
    public void GameOver(bool flag)
    {
        isGameOver = flag;
        if (isGameOver == true)
        {
            Debug.Log("Game Over");
            deathScreenUI.SetActive(true);
        }
        else
        {
            deathScreenUI.SetActive(false);
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
        winScreenUI.SetActive(true);
        playerProfileSO.NumOfLevelsComplete++;
        playerProfileSO.LevelsComplete[(int)playerProfileSO.CurrentLevel - 1] = true;
        PlayerPrefs.SetInt("Profile: " + playerProfileSO.ToString(), playerProfileSO.NumOfLevelsComplete);
        // Save the levels completed array
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            PlayerPrefs.SetInt("Profile: " + playerProfileSO.ToString() + ":Level" + (i + 1), playerProfileSO.LevelsComplete[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
        Debug.Log("Game Won " + playerProfileSO.LevelsComplete[(int)playerProfileSO.CurrentLevel - 1]);
    }

    public void CheckScore(int score)
    {
        int targetScore = (int)currentLevel * LEVEL_SCORE_INCREMENT;
        scoreSO.Value = score;
        PlayerPrefs.SetFloat("Score", scoreSO.Value);
        PlayerPrefs.Save();

        if (score >= targetScore)
        {
            GameWon();
        }
    }

    public void SelectProfile(int profileNum)
    {
        currentProfile = profileNum;
        playerProfileSO.CurrentProfile = profileNum;
        // playerProfileSO.NumOfLevelsComplete = PlayerPrefs.GetInt("Profile: " + playerProfileSO.ToString(), 0);
    }

    public string ProfileDetails(int profileNum)
    {
        string profileDetails = "Profile " + profileNum + "\n";
        profileDetails += "Levels Complete: " + PlayerPrefs.GetInt("Profile: " + playerProfileSO.ToString(), 0) + "\n";
        for (int i = 0; i < playerProfileSO.LevelsComplete.Length; i++)
        {
            profileDetails += "Level " + (i + 1) + ": " + (PlayerPrefs.GetInt("Profile: " + playerProfileSO.ToString() + ":Level" + (i + 1), 0) == 1 ? "Complete" : "Incomplete") + "\n";
        }
        return profileDetails;
    }
}
