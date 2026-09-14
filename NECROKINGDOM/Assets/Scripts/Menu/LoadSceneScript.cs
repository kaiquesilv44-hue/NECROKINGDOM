using UnityEngine;

public class LoadSceneScript : MonoBehaviour
{
    public string sceneName;
    public void LoadScene()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
