using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Onda1
{
    public string nome;        
    public GameObject prefab;  
    public int quantidade;
    public List<Transform> caminho;
}
[System.Serializable]
public class Onda2
{
    public string nome;
    public GameObject prefab;
    public int quantidade;
    public List<Transform> caminho;
}
[System.Serializable]
public class Onda3
{
    public string nome;
    public GameObject prefab;
    public int quantidade;
    public List<Transform> caminho;
}

[System.Serializable]
public class OndaBoss
{
    public string nome;
    public GameObject prefab;
    public int quantidade;
    public List<Transform> caminho;
}

public class InimigoSpawner : MonoBehaviour
{
    public int QuantidadeInimigosOnda1;
    public int QuantidadeInimigosOnda2;
    public int QuantidadeInimigosOnda3;
    public int QuantidadeInimigosOndaBoss;
    public float tempoEntreOndas = 15f;
    public float tempoEntreInimigos = 1f;
    public TextMeshProUGUI Temporizador;
    public List<Onda1> InimigosOnda1;
    public List<Onda2> InimigosOnda2;
    public List<Onda3> InimigosOnda3;
    public List<OndaBoss> InimigosOndaBoss;

    void Start()
    {
        StartCoroutine(temporizador());
    }

    IEnumerator SpawnarOnda1()
    {
        foreach (Onda1 info in InimigosOnda1)
        {
            for (int i = 0; i < info.quantidade; i++)
            {
                GameObject novoInimigo = Instantiate(info.prefab, transform.position, Quaternion.identity);

                CaminhoInimigo movimento = novoInimigo.GetComponent<CaminhoInimigo>();
                if (movimento != null)
                {
                    movimento.caminho = info.caminho;
                    movimento.Incremento = 0.25f / QuantidadeInimigosOnda1; 
                }
                yield return new WaitForSeconds(tempoEntreInimigos);
            }
        }
    }

    IEnumerator SpawnarOnda2()
    {
        foreach (Onda2 info in InimigosOnda2)
        {
            for (int i = 0; i < info.quantidade; i++)
            {
                GameObject novoInimigo = Instantiate(info.prefab, transform.position, Quaternion.identity);

                CaminhoInimigo movimento = novoInimigo.GetComponent<CaminhoInimigo>();
                if (movimento != null)
                {
                    movimento.caminho = info.caminho;
                    movimento.Incremento = 0.25f / QuantidadeInimigosOnda2;
                }
                yield return new WaitForSeconds(tempoEntreInimigos);
            }
        }
    }

    IEnumerator SpawnarOnda3()
    {
        foreach (Onda3 info in InimigosOnda3)
        {
            for (int i = 0; i < info.quantidade; i++)
            {
                GameObject novoInimigo = Instantiate(info.prefab, transform.position, Quaternion.identity);

                CaminhoInimigo movimento = novoInimigo.GetComponent<CaminhoInimigo>();
                if (movimento != null)
                {
                    movimento.caminho = info.caminho;
                    movimento.Incremento = 0.25f / QuantidadeInimigosOnda3;
                }
                yield return new WaitForSeconds(tempoEntreInimigos);
            }
        }
    }

    IEnumerator SpawnarOndaBoss()
    {
        foreach (OndaBoss info in InimigosOndaBoss)
        {
            for (int i = 0; i < info.quantidade; i++)
            {
                GameObject novoInimigo = Instantiate(info.prefab, transform.position, Quaternion.identity);

                CaminhoInimigo movimento = novoInimigo.GetComponent<CaminhoInimigo>();
                if (movimento != null)
                {
                    movimento.caminho = info.caminho;
                    movimento.Incremento = 0.25f / QuantidadeInimigosOndaBoss;
                }
                yield return new WaitForSeconds(tempoEntreInimigos);
            }
        }
    }

   public IEnumerator TempoEntreOndas()
    {
        yield return new WaitForSeconds(tempoEntreOndas);

        switch(FindAnyObjectByType<LevelManagerScript>().BarraAtual)
        {
            case 0.25f:
                StartCoroutine(SpawnarOnda2());
                StartCoroutine(temporizador());
                break;
            case 0.5f:
                StartCoroutine(SpawnarOnda3());
                StartCoroutine(temporizador());
                break;
            case 0.75f:
                StartCoroutine(SpawnarOndaBoss());
                StartCoroutine(temporizador());
                break;
        }
    }

   public IEnumerator temporizador()
    {
        Temporizador.gameObject.SetActive(true);
        for (int i = 15; i >= 0; i--)
        {
            Temporizador.text = "Inimigos Chegarão em: " + i.ToString();
            yield return new WaitForSeconds(1f);
        }
        Temporizador.gameObject.SetActive(false);
        if(FindAnyObjectByType<LevelManagerScript>().BarraAtual <= 0.25f)
        {
            StartCoroutine(SpawnarOnda1());
        }
    }
}