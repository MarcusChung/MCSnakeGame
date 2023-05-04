using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResetProgressDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private GameObject confirmResetPanel;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // dropdown.onValueChanged.AddListener(delegate { HandleDropdownData(dropdown.value); });
    }

    public void HandleDropdownData(int val)
    {
        if (val == 1)
        {
            gameManager.ResetStats(1);
        } else if (val == 2) {
            gameManager.ResetStats(2);
        } else if (val == 3){
            gameManager.ResetStats(3);
        }
    }

    public void ConfirmReset()
    {
        int val = dropdown.value;
        FindObjectOfType<GameManager>().ResetStats(val);
        FindObjectOfType<ProfileDetails>().UpdateProfileDescText();
        // confirmResetPanel.SetActive(false);
    }
}
