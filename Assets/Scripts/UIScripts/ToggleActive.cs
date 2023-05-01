using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActive : MonoBehaviour
{
    
    [SerializeField] private Button closeButton;
    private void Start()
    {
        Button btn = closeButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

   private void TaskOnClick()
    {
        transform.parent.gameObject.SetActive(!transform.parent.gameObject.activeSelf);
    }
}
