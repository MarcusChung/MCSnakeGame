using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    [SerializeField] private GameObject deathScreenUI;
    public void GameOver()
    {
        if (!isGameOver) {
        Debug.Log("Game Over");
        isGameOver = true;
        deathScreenUI.SetActive(true);
        }
    }

    public void SwitchGameOverState(){
        isGameOver = !isGameOver;
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameWon()
    {
        Debug.Log("Game Won");
    }
}
