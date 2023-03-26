using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isGameOver { get; private set; } = false;
    private int score = 0;
    // private int poisonAccumulation = 0;
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private GameObject winScreenUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform player;

    public GameObject foodPrefab;
    public int numFoodObjects = 10;
    public void GameOver(bool flag)
    {
        isGameOver = flag;
        if (isGameOver == true) {
        Debug.Log("Game Over");
        deathScreenUI.SetActive(true);
        // Time.timeScale = 0; i will avoid using timescale as animations won't work
        // FindObjectOfType<Snake>().HideSnakeHead();
        } else {
            deathScreenUI.SetActive(false);
        }
    }

    public void GameWon()
    {
    //    FindObjectOfType<Snake>().HideSnakeHead();
       winScreenUI.SetActive(true);
       Debug.Log("Game Won");
    }

    [Tooltip("case 1 = level 1, case 2 = level 2, etc...")]
    public void CheckScore()
    {
         int scene = SceneManager.GetActiveScene().buildIndex;
        //if the scene is scene 1, and the score is 10 then game won
        
        switch(scene){
            case 1:
            if (GetScore() == 10) GameWon();
            // if (GetScore() == 2) SpawnObject();
            break;
            case 2:
            if (GetScore() == 20) GameWon();
            break;
            case 3:
            if (GetScore() == 30) GameWon();
            break;
            case 4:
            if (GetScore() == 40) GameWon();
            break;
        }
    }

    public int GetScore()
    {
        score = player.GetComponent<Snake>().GetScore();
        return score;
    }

}
