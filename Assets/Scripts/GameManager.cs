using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameOver { get; private set; } = false;
    public int score { get; private set; } = 0;
    ScoreSystem scoreSystem;
    // private int poisonAccumulation = 0;
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private GameObject winScreenUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform player;
    private Level currentLevel;
    private const int LEVEL_SCORE_INCREMENT = 10;
    public GameObject foodPrefab;
    public int numFoodObjects = 10;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        score = scoreSystem.CurrentScore;
    }
    public void GameOver(bool flag)
    {
        isGameOver = flag;
        if (isGameOver == true)
        {
            Debug.Log("Game Over");
            deathScreenUI.SetActive(true);
            // Time.timeScale = 0; i will avoid using timescale as animations won't work
            // FindObjectOfType<Snake>().HideSnakeHead();

            Debug.Log("Score = " + score + " setting score to score system");
            scoreSystem.SetScore(score);
        }
        else
        {
            deathScreenUI.SetActive(false);
        }
    }

    public enum Level
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
    public void GameWon()
    {
        //FindObjectOfType<Snake>().HideSnakeHead();
        Debug.Log("Score = " + score + " setting score to score system");
        scoreSystem.SetScore(score);
        winScreenUI.SetActive(true);
        Debug.Log("Game Won");
    }

    public void CheckScore(int score)
    {
        Level currentLevel = (Level)SceneManager.GetActiveScene().buildIndex;
        int targetScore = (int)currentLevel * LEVEL_SCORE_INCREMENT;
        this.score = score;
        Debug.Log("Target score = " + targetScore + " current score = " + score);
        if (score >= targetScore)
        {
            GameWon();
        }
    }

}
