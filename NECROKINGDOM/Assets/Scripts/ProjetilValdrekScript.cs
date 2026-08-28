using UnityEngine;

public class ProjetilValdrekScript : MonoBehaviour
{
    public Transform Alvo;
    public float Velocidade = 5f;


    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        Vector3 direcao = (Alvo.position - transform.position).normalized;

        Vector3 movimento = (direcao * Velocidade * Time.deltaTime);

        transform.Translate(movimento);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
        }
    }
}
