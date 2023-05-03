using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public void OpenSelectedPanel(GameObject panel)
    {
        panel.SetActive(true);

        //hide current panel
        gameObject.SetActive(false);
    }
}
