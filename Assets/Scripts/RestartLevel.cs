using UnityEngine.UI;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    //button trigger
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject deathScreenUI;
    // Update is called once per frame
   void Start () {
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		FindObjectOfType<GameManager>().RestartGame();
        FindObjectOfType<GameManager>().switchGameOverState();
        deathScreenUI.SetActive(false);
	}
}
