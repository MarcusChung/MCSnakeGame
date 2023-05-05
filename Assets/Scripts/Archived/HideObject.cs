using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField] private GameObject gObject;
    // public void Hide()
    // {
    //     gObject.SetActive(false);
    // }

    private void Start()
    {
        // gObject.SetActive(false);
        GameManager.Instance.GameOver(true);
    }
}
