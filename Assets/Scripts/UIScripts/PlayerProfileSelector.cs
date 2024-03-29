using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerProfileSelector : MonoBehaviour
{
    private TextMeshProUGUI profileNumText;
    private TextMeshProUGUI profileDescText;
    private Button button;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void CheckProfileSelected(TextMeshProUGUI profileNumText)
    {
        gameManager = FindObjectOfType<GameManager>();
        if (profileNumText.text.Contains("1"))
        {
            gameManager.SelectProfile(1);
        }
        else if (profileNumText.text.Contains("2"))
        {
            gameManager.SelectProfile(2);
        }
        else if (profileNumText.text.Contains("3"))
        {
            gameManager.SelectProfile(3);
        }
        else
        {
            gameManager.SelectProfile(0);
        }
    }
}
