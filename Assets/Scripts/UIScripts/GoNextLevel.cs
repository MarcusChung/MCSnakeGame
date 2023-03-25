using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : MonoBehaviour
{
    private int scene;
    private void Awake() {
        scene = SceneManager.GetActiveScene().buildIndex;
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(scene + 1);
    }
}
