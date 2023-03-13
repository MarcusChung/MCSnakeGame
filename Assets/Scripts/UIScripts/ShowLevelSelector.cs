using UnityEngine;
using UnityEngine.UI;


public class ShowLevelSelector : MonoBehaviour
{

    [SerializeField] private Button showSelectLevel;
    [SerializeField] private GameObject selectLevelPanel;
    // Start is called before the first frame update
    private void Start()
    {
        Button btn = showSelectLevel.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

   private void TaskOnClick()
    {
       selectLevelPanel.SetActive(true);
    }
}
