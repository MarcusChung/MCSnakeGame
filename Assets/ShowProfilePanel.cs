using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowProfilePanel : MonoBehaviour
{
  
    [SerializeField] private Button showSelectButton;
    [SerializeField] private GameObject selectProfilePanel;

    private void Start()
    {
        Button btn = showSelectButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

   private void TaskOnClick()
    {
       selectProfilePanel.SetActive(true);
    }
}
