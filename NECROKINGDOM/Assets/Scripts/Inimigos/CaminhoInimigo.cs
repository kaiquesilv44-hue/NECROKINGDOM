using System.Collections.Generic;
using UnityEngine;

public class CaminhoInimigo : MonoBehaviour
{
    public List<Transform> caminho;
    private int indiceAtual = 0;
    public float velocidade = 3f;
    public float Vida = 20f;
    public float Escudo = 0f;

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
    }

    private void OnDestroy()
    {
        LevelManagerScript Manager = FindAnyObjectByType<LevelManagerScript>();
        InimigoSpawner Spawner = FindAnyObjectByType<InimigoSpawner>();
        Manager.BarraAtual += Incremento;
        if(Manager.BarraAtual >= 0.249 && Manager.BarraAtual <= 0.250001)
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
        if (Manager.BarraAtual >= 0.9)
        {
            Manager.BarraAtual = 1f;
        }
    }
}