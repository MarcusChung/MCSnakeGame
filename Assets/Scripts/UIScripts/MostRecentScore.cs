using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MostRecentScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Recent Score: " + PlayerPrefs.GetFloat("Score", 0f).ToString();
    }

}
