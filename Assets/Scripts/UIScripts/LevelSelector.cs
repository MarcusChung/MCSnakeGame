using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button levelSelectButton;
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = levelSelectButton.GetComponent<Button>();
        btn.onClick.AddListener(OpenScene);

    }

    private void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
