using System.Collections.Generic;
using UnityEngine;

public class CaminhoInimigo : MonoBehaviour
{
    public List<Transform> caminho;
    private int indiceAtual = 0;
    public float velocidade = 3f;
    public float Vida = 20f;
    public float Escudo = 0f;
    public int Almas = 5;
    public string NomeInimigo;

    public float Incremento;

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
    }

    private void Mago()
    {

    }

    private void Bardo()
    {

    }

    private void Barbaro()
    {
        if (Vida <= 8 && NomeInimigo == "Barbaro")
        {
            velocidade = 6.5f;
            Escudo = 1f;
        }
    }

    private void Ladino()
    {

    }



    private void OnDestroy()
    {
        LevelManagerScript Manager = FindAnyObjectByType<LevelManagerScript>();
        InimigoSpawner Spawner = FindAnyObjectByType<InimigoSpawner>();
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