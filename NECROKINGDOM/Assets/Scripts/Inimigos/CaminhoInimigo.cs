using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaminhoInimigo : MonoBehaviour
{
    LevelManagerScript Manager;
    InimigoSpawner Spawner;
    SpriteRenderer sr;

    public List<Transform> caminho;
    private int indiceAtual = 0;
    public float velocidade = 3f;
    public float Vida = 20f;
    public float Escudo = 0f;
    public int Almas = 5;
    public string NomeInimigo;
    public GameObject Particulas;

    public float Incremento;

    void Start()
    {
        Manager = FindAnyObjectByType<LevelManagerScript>();
        Spawner = FindAnyObjectByType<InimigoSpawner>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (indiceAtual >= caminho.Count) return; 

        Transform alvo = caminho[indiceAtual];
        transform.position = Vector3.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, alvo.position) < 0.1f)
        {
            indiceAtual++; 
        }

        if (Vida <= 0)
        {
            Destroy(gameObject);
        }

        switch (NomeInimigo)
        {
            case "Mago":
                Mago();
                break;
            case "Bardo":
                Bardo();
                break;
            case "Barbaro":
                Barbaro();
                break;
            case "Ladino":
                Ladino();
                break;
        }
    }

    public void ReceberDano(float dano)
    {
        dano -= Escudo;
        Vida -= dano;
        StartCoroutine(Receberdano());
        if(NomeInimigo == "Ladino")
        {
            StartCoroutine(ladino());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(NomeInimigo == "Mago")
        {
            if (collision.CompareTag("Torre"))
            {
                TorreScript torre = collision.GetComponent<TorreScript>();
                torre.MagosNaArea++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (NomeInimigo == "Mago")
        {
            if (collision.CompareTag("Torre"))
            {
                TorreScript torre = collision.GetComponent<TorreScript>();
                torre.MagosNaArea--;
            }
        }
    }



    private void Mago()
    {

    }

    private void Bardo()
    {

    }

    private void Barbaro()
    {
        if (Vida <= 8)
        {
            velocidade = 5.4f;
            Escudo = 4f;
        }
    }

    private void Ladino()
    {

    }

    IEnumerator ladino()
    {
        TorreScript[] todasTorres = FindObjectsByType<TorreScript>(FindObjectsSortMode.None);
        foreach (TorreScript torre in todasTorres)
        {
            if (torre.EstaNaListaDeInimigos(gameObject.transform))
                torre.Inimigos.Remove(gameObject.transform);
        }
        gameObject.tag = "Ladino";
        float dano = 0.5f;
        Color corOriginal = sr.color;
        Color Dano = new Color(corOriginal.r, corOriginal.g, corOriginal.b, dano);
        sr.color = Dano;
        yield return new WaitForSeconds(4f);
        sr.color = corOriginal;
        gameObject.tag = "Inimigo";
    }



    private void OnDestroy()
    {
        if (Manager != null && gameObject.scene.isLoaded)
        {
            if (gameObject.scene.isLoaded)
                Instantiate(Particulas, transform.position, Quaternion.identity);

            Manager.BarraAtual += Incremento;
            Manager.Almas += Almas;
            if (Manager.BarraAtual >= 0.249 && Manager.BarraAtual <= 0.250001)
            {
                Manager.BarraAtual = 0.25f;
                Spawner.StartCoroutine(Spawner.TempoEntreOndas());
            }
            if (Manager.BarraAtual >= 0.499 && Manager.BarraAtual <= 0.50001)
            {
                Manager.BarraAtual = 0.5f;
                Spawner.StartCoroutine(Spawner.TempoEntreOndas());
            }
            if (Manager.BarraAtual >= 0.749 && Manager.BarraAtual <= 0.750001)
            {
                Manager.BarraAtual = 0.75f;
                Spawner.StartCoroutine(Spawner.TempoEntreOndas());
            }
            if (Manager.BarraAtual >= 0.999 && Manager.BarraAtual <= 1.00001)
            {
                Manager.BarraAtual = 1f;
            }
        }
    }

    IEnumerator Receberdano()
    {
        if (NomeInimigo != "Ladino") 
        { 
          sr.color = Color.red;
          yield return new WaitForSeconds(0.1f);
          sr.color = Color.white;
        }
    }
}