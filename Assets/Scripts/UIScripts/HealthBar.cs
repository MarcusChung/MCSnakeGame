using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthBar : MonoBehaviour
{
     private TextMeshProUGUI hPText;
     [SerializeField] private PlayerProfileSO playerProfile;
     public int hP{get; private set;}
    void Start()
    {
       hPText = GetComponent<TextMeshProUGUI>();
       hP = 5;
       playerProfile.HP = hP;
    }

    public void UpdateHealth(int health)
    {
        hPText.text = "HP: " + health.ToString() + "/5";
    }

    public void MinusHealth()
    {
        hP--;
        playerProfile.HP = hP;
        hPText.text = "HP: " + hP + "/5";
    }
}
