using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Update is called once per frame
    private void Update()
    {
        scoreText.SetText(FindObjectOfType<GameManager>().GetScore().ToString());
    }
}
