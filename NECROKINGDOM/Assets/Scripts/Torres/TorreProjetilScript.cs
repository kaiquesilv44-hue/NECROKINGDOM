using UnityEngine;

public class TorreProjetilScript : MonoBehaviour
{
    public float Velocidade = 5f;
    public float Dano = 3f;
    public Transform Alvo;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        if (Alvo != null)
        {
            Vector3 direction = (Alvo.position - transform.position).normalized;
            transform.Translate(direction * Velocidade * Time.deltaTime, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<CaminhoInimigo>().ReceberDano(Dano);
        }
    }
}
