using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour
{
    //button trigger
    [SerializeField] private Button restartButton;
    // [SerializeField] private GameObject screenUI;
    // Update is called once per frame
    private void Start()
    {
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        RestartGame();
        // screenUI.SetActive(false);
    }

    private void RestartGame()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<GameManager>().GameOver(false);
    }
}
