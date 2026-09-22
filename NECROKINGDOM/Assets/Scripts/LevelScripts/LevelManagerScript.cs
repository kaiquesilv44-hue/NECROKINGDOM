using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public bool onda1 = true;
    public bool onda2 = false;
    public bool onda3 = false;
    public bool onda4 = false;

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
    public bool Removido = false;
    public bool Posicionando = false;
    public Button Bt2X;
    public Sprite Btpressionado;
    public Sprite Btoriginal;
    public List<GameObject> SlotDeTorre = new List<GameObject>();
    public List<GameObject> SlotDeArmadilha = new List<GameObject>();


    private void Start()
    {
        Time.timeScale = 1f;
        Vida = 10;
        BarraDeOnda.fillAmount = 0;
        MenuVitoria.SetActive(false);
        MenuPausa.SetActive(false);
        foreach (GameObject slot in SlotDeTorre)
        {
            slot.SetActive(false);
        }
        foreach (GameObject slot in SlotDeArmadilha)
        {
            slot.SetActive(false);
        }
    }

    private void Update()
    {
        if (Time.timeScale == 2)
            Bt2X.image.sprite = Btpressionado;
        else
            Bt2X.image.sprite = Btoriginal;
        
        SlotDeTorre.RemoveAll(slot => slot == null);
        SlotDeArmadilha.RemoveAll(slot => slot == null);
        if (Posicionando)
        {
            foreach (GameObject slot in SlotDeTorre)
            {
                slot.SetActive(true);
            }
            foreach (GameObject slot in SlotDeArmadilha)
            {
                slot.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject slot in SlotDeTorre)
            {
                slot.SetActive(false);
            }
            foreach (GameObject slot in SlotDeArmadilha)
            {
                slot.SetActive(false);
            }
        }

        VidaText.text = Vida.ToString();
        AlmasText.text = Almas.ToString();
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

    public void Remover()
    {
        Removido = true;
    }
}
