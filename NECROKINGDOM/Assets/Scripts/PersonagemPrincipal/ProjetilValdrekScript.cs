using UnityEngine;

public class ProjetilValdrekScript : MonoBehaviour
{
    public float Velocidade = 5f;
    public float Dano = 3f;


    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Velocidade * Time.deltaTime);
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
