using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(FloatSO))]
public class HighScoreSave : MonoBehaviour
{
    private TextMeshProUGUI highScore;
    [SerializeField] PlayerProfileSO playerProfileSO;
    // Start is called before the first frame update
    void Start()
    {
       highScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (highScore != null)
        {
            Debug.Log("HighScoreSave: " + highScore.text);
            playerProfileSO.HighScore = highScore.text;
        }
    }
}
