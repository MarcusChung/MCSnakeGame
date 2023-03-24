using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 0.2f;
        pauseMenu.SetActive(false);
    }

    public void Home(int sceneId)
    {
        Time.timeScale = 0.2f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
