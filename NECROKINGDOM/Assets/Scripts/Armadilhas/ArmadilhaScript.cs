using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ArmadilhaScript : MonoBehaviour
{
    private float Cooldown = 4f;
    private bool PodeAtivar = true;
    public LevelManagerScript Manager;
    SpriteRenderer sr;
    public Sprite ativado;
    public Sprite original;
    public GameObject Slot;
    public Collider2D col;
    private bool Posicionado = false;
    private bool PodeRemover = false;
    public LayerMask PontosDeArmadilha;
    public int Custo = 10;
    public float Dano = 8f;


    private void Start()
    {
        Manager = FindAnyObjectByType<LevelManagerScript>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!PodeAtivar)
            sr.sprite = ativado;
        else
            sr.sprite = original;


       if(Input.GetMouseButtonDown(0))
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Manager.Removido && col.OverlapPoint(mousepos))
        {
            Manager.Removido = false;
            Destroy(gameObject);
        }
    }

        if (Posicionado)
        {
            PodeRemover = true;
        }
        if (!Posicionado)
        {
            Manager.Posicionando = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Collider2D Ponto = Physics2D.OverlapCircle(mousePosition, 0.5f, PontosDeArmadilha);

            if (Ponto != null)
            {
                transform.position = Ponto.transform.position;
            }
            else
            {
                transform.position = mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Collider2D Ponto = Physics2D.OverlapCircle(transform.position, 0.5f, PontosDeArmadilha);
            if (Ponto == null && !Posicionado)
            {
                Destroy(gameObject);
            }
            else if (Ponto != null)
            {
                Destroy(Ponto.gameObject);
                Manager.SlotDeArmadilha.RemoveAll(slot => slot == null);
            }
            Posicionado = true;
            Manager.Posicionando = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PodeAtivar && collision.CompareTag("Inimigo"))
        {
            collision.GetComponent<CaminhoInimigo>().ReceberDano(Dano);
            PodeAtivar = false;
            StartCoroutine(Desativando());
        }
    }

    IEnumerator Desativando()
    {
        yield return new WaitForSeconds(Cooldown);
        PodeAtivar = true;
    }

    private void OnDestroy()
    {
        Manager.Almas += Custo;

        if (PodeRemover && gameObject.scene.isLoaded)
        {
            GameObject NovoSlot = Instantiate(Slot, transform.position, Quaternion.identity);
            Manager.SlotDeArmadilha.Add(NovoSlot);
        }
    }
}
