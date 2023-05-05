using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonScreen : MonoBehaviour, IScreen
{
    [SerializeField] private GameObject gameWonScreen;
    public void ShowScreen()
    {
        gameWonScreen.SetActive(true);
        
    }

    public void HideScreen()
    {
        gameWonScreen.SetActive(false);
    }
}
