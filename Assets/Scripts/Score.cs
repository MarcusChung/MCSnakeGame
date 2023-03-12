using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Update is called once per frame
    private void Update()
    {
        scoreText.SetText(player.GetComponent<Snake>().GetScore().ToString());
        
    }
}
