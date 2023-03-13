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

    private void OpenScene() {
        try {
            SceneManager.LoadScene(sceneName);
        } catch (System.Exception e) {
            Debug.Log("Scene not found: Check spelling of scene and try again");
        }
    } 
}
