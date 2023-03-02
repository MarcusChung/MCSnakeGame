using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadDeathScreen : MonoBehaviour
{

    public void ShowDeathScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
