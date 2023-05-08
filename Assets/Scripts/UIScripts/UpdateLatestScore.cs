using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLatestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private FloatSO scoreSO;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreSO.Value.ToString();
    }
}
