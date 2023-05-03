using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActive : MonoBehaviour
{
    public void ToggleView()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
