using System.Collections;
using System.Collections.Generic;
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

public class InimigoSpawner : MonoBehaviour
{
    public List<Onda1> InimigosOnda1;
    public List<Onda2> InimigosOnda2;
    public List<Onda3> InimigosOnda3;

    void Start()
    {
        StartCoroutine(SpawnarOnda1());
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
                }
                yield return new WaitForSeconds(1f);
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
                }
                yield return new WaitForSeconds(1f);
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
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}