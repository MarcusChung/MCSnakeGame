using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MostRecentScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerProfileSO playerProfileSO;
    // Start is called before the first frame update
    void Start()
    {
        // scoreText.text = "Recent Score: " + GameManager.Instance.GetLastScore();
        scoreText.text = "Recent Score: " + GameManager.Instance.LastScore;
    }

}
