using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementsShow : MonoBehaviour
{
    [SerializeField] private PlayerProfileSO playerProfileSO;
    [SerializeField] private GameObject achievementItemPrefab;

    private void OnEnable()
    {
        LoadAchievements();
    }

    private void LoadAchievements()
    {
        FindObjectOfType<DataPersistenceManager>().LoadGame(playerProfileSO.CurrentProfile.ToString());

        // Remove all existing achievement items
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Load and display new achievement items
        for (int i = 0; i < playerProfileSO.UnlockedAchievements.Length; i++)
        {
            if (!string.IsNullOrEmpty(playerProfileSO.UnlockedAchievements[i]))
            {
                GameObject achievementItem = Instantiate(achievementItemPrefab, transform);
                achievementItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Achievement " + i;
                achievementItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerProfileSO.UnlockedAchievements[i];
            }
        }
    }
}