using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AchievementPanel: MonoBehaviour, IScreen
{
    [SerializeField] private GameObject achievementPanel;
    [SerializeField] private TextMeshProUGUI achievementTextTitle;
    public void ShowScreen()
    {
        achievementPanel.SetActive(true);
    }

    public void HideScreen()
    {
        achievementPanel.SetActive(false);
    }

    public void ShowAchievement(string achievementName)
    {
        achievementTextTitle.text = achievementName;
        ShowScreen();
    }
}