using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AchievementsShow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerProfileSO playerProfileSO;
    void Start()
    {
        GameObject achievementItem = transform.GetChild(0).gameObject;
        GameObject g;
        for (int i = 0; i < playerProfileSO.UnlockedAchievements.Length; i++)
        {
            if (playerProfileSO.UnlockedAchievements[i] != "")
            {
                g = Instantiate(achievementItem, transform);
                g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Achievement " + (i);
                g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerProfileSO.UnlockedAchievements[i];
            }
        }
        Destroy(achievementItem);
    }

}
