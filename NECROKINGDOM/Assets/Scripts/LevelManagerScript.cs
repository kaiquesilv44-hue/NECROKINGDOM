using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public Image BarraDeOnda;
    public float BarraAtual = 0f;
    public TextMeshProUGUI VidaText;
    public TextMeshProUGUI AlmasText;
    public int Vida;
    public int Almas;
    public bool Pausado = false;
    public bool x2Ativado = false;
    public GameObject MenuPausa;
    public GameObject MenuVitoria;
    public GameObject MenuDerrota;


    private void Start()
    {
        Time.timeScale = 1f;
        Vida = 10;
        Almas = 0;
        BarraDeOnda.fillAmount = 0;
        MenuVitoria.SetActive(false);
        MenuPausa.SetActive(false);
    }

    private void Update()
    {
        VidaText.text = "Vida: " + Vida.ToString();
        AlmasText.text = "Almas: " + Almas.ToString();
        BarraDeOnda.fillAmount = BarraAtual;


        if(BarraAtual == 1f)
        {
            MenuVitoria.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Vida <= 0)
        {
            Time.timeScale = 0f;
            MenuDerrota.SetActive(true);
        }

        if (Pausado)
        {
            MenuPausa.SetActive(true);
        }
        else
        {
            MenuPausa.SetActive(false);
        }
    }

    public void Pausar()
    {
        if (x2Ativado)
        {
            x2Ativado = false;
            Pausado = true;
            Time.timeScale = 0;

        }
        else if (!x2Ativado)
        {
            Pausado = !Pausado;
            Time.timeScale = Pausado ? 0 : 1;
        }
    }

    public void x2()
    {
        if (!Pausado)
        {
            x2Ativado = !x2Ativado;
            Time.timeScale = x2Ativado ? 2 : 1;
        }
    }


}
