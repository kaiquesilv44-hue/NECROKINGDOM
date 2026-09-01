using UnityEngine;

public class InimigoScript : MonoBehaviour
{
    public Vector3[] pontos = new Vector3[]
    {
        new Vector3(4.5f, -6.2f, 0f),
        new Vector3(4.5f, 2.46f, 0f),
        new Vector3(2f, 2.46f, 0f),
        new Vector3(2f, -2.34f, 0f),
        new Vector3(-1.5f, -2.34f, 0f),
        new Vector3(-1.5f, -1.7f, 0f),
        new Vector3(-3.4f, 1.7f, 0f),
        new Vector3(-3.4f, 6f, 0f)
    };

    public float velocidade = 5f;
    public float Vida; 
    private int indiceAtual = 0;

    void Update()
    {
        // já passou por todos os pontos
        if (indiceAtual >= pontos.Length)
        {
            return;
        }

        Vector3 destino = pontos[indiceAtual];

        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            indiceAtual++;
        }
    }
}