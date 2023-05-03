using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ReadScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Update is called once per frame
    private void Update()
    {
        // scoreText.SetText(FindObjectOfType<GameManager>().scoreSO.Value.ToString());
    }
}
