using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour, IScreen
{
    [SerializeField] private GameObject deathScreen;

    public void ShowScreen()
    {
        deathScreen.SetActive(true);
        
    }

    public void HideScreen()
    {
        deathScreen.SetActive(false);
    }
}
