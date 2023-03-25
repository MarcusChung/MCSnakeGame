using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour
{
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
