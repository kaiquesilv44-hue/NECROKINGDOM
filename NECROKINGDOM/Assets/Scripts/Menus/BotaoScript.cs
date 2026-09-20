using System.ComponentModel.Design.Serialization;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoScript : MonoBehaviour
{
    public int Botao;
    public GameObject Painel;

    public void Click()
    {
        switch (Botao)
        {
            case 1: SceneManager.LoadScene("SeleçãoMasmorra"); break;
            case 2: SceneManager.LoadScene("Coleção"); break;
            case 3: Painel.SetActive(true); break;
            case 4: Application.Quit(); break;
            case 5: Painel.SetActive(false); break;
        }
    }

}
