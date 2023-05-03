using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPanel : MonoBehaviour
{

    [SerializeField] private Button selectButton;
    [SerializeField] private GameObject selectPanel;

    private void Start()
    {
        Button btn = selectButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        selectPanel.SetActive(true);
    }
}
