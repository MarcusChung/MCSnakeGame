using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TMP_Dropdown))]
public class ResetProgressDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // dropdown.onValueChanged.AddListener(delegate { HandleDropdownData(dropdown.value); });
    }

    public void ConfirmReset()
    {
        Debug.Log("ConfirmReset");
        int val = dropdown.value;
        // FindObjectOfType<GameManager>().ResetStats(val);#
        Debug.Log("Resetting stats for profile " + GameManager.Instance.profilePrefix + val);
        FindObjectOfType<DataPersistenceManager>().DeleteSave(GameManager.Instance.profilePrefix + val);
        FindObjectOfType<ProfileDetails>().UpdateProfileDescText();
        // confirmResetPanel.SetActive(false);
    }
}
