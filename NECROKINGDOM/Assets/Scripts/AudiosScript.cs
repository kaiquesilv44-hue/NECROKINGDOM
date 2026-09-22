using UnityEngine;
using UnityEngine.SceneManagement;

public class AudiosScript : MonoBehaviour
{
    AudioSource ad;
    void Awake()
    {
        ad = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += QuandoCenaCarregou;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= QuandoCenaCarregou;
    }

    void QuandoCenaCarregou(Scene cena, LoadSceneMode modo)
    {
        if (cena.name == "Cena1")
            ad.Pause();
        else
            if(!ad.isPlaying)
            ad.Play();
            
    }
}
