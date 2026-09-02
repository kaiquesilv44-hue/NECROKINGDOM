using UnityEngine;

public class LoadSceneScript : MonoBehaviour
{
    public string sceneName;
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
