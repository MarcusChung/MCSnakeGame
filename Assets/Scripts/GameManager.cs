using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    private int score = 0;
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform player;
    public void GameOver(bool flag)
    {
        isGameOver = flag;
        if (isGameOver == true) {
        Debug.Log("Game Over");
        deathScreenUI.SetActive(true);
        } else {
            deathScreenUI.SetActive(false);
        }
    }

    public void GameWon()
    {
        Debug.Log("Game Won");
    }

    public int GetScore()
    {
        score = player.GetComponent<Snake>().GetScore();
        return score;
    }
}
