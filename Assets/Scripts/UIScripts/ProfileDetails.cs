using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileDetails : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI profileDescText;
    [SerializeField] private int profileNum;
    private GameManager gameManager;

    void Start()
    {
        profileDescText.text = FindObjectOfType<GameManager>().ProfileDetails(profileNum);
    }

    public void UpdateProfileDescText()
    {
        profileDescText.text = FindObjectOfType<GameManager>().ProfileDetails(profileNum);
        Debug.Log("UpdateProfileDescText");
        profileDescText.ForceMeshUpdate();
    }
}
