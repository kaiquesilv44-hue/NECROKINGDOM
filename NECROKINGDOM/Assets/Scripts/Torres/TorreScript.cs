using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TorreScript : MonoBehaviour
{
    public GameObject TorreProjetil;
    public GameObject LocalTorreProjetil;
    public GameObject Slot;
    public LevelManagerScript Manager;
    public Collider2D col;
    private bool Cooldown = true;
    private float MenorDistancia = math.INFINITY;
    public Transform Alvo;
    public float CoolDown = 5f;
    public float Dano = 5f;
    public int Custo = 10;
    private bool Posicionado = false;
    private bool PodeRemover = false;
    public LayerMask PontosDeTorre;
    public int MagosNaArea = 0;

    public List<Transform> Inimigos = new List<Transform> ();


    private void Start()
    {
        Manager = FindAnyObjectByType<LevelManagerScript> ();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            Inimigos.RemoveAll(inimigo => inimigo == null);
            if (Inimigos.Count > 0 && Cooldown)
            {
                MenorDistancia = math.INFINITY;
                foreach (Transform t in Inimigos)
                {
                    float distancia = Vector3.Distance(transform.position, t.position);
                    if (distancia < MenorDistancia)
                    {
                        MenorDistancia = distancia;
                        Alvo = t;
                    }
                }
                StartCoroutine(cooldown());
                Cooldown = false;
                if (MagosNaArea >= 1)
                    return;
                GameObject proj = Instantiate(TorreProjetil, LocalTorreProjetil.transform.position, LocalTorreProjetil.transform.rotation);
                proj.GetComponent<TorreProjetilScript>().Alvo = Alvo;
                proj.GetComponent<TorreProjetilScript>().Dano = Dano;
               
            }
        }
        
        if(!Posicionado)
        {
            Manager.Posicionando = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Collider2D Ponto = Physics2D.OverlapCircle(mousePosition, 0.5f, PontosDeTorre);

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
            Collider2D Ponto = Physics2D.OverlapCircle(transform.position, 0.5f, PontosDeTorre);
            if (Ponto == null && !Posicionado)
            {
                Destroy(gameObject);
            }
            else if(Ponto != null)
            {
                Destroy(Ponto.gameObject);
                Manager.SlotDeTorre.RemoveAll(slot => slot == null);
            }
            Posicionado = true;
            Manager.Posicionando = false;
        }
    }

    public bool EstaNaListaDeInimigos(Transform alvo)
    {
        return Inimigos.Contains(alvo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Inimigos.Add(collision.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!EstaNaListaDeInimigos(collision.transform) && collision.gameObject.CompareTag("Inimigo"))
        {
            Inimigos.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Inimigos.Remove(collision.transform);
        }
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(CoolDown);
        Cooldown = true;
    }

    private void OnDestroy()
    {
        Manager.Almas += Custo;
        if (PodeRemover && gameObject.scene.isLoaded)
        {
            GameObject NovoSlot = Instantiate(Slot, transform.position, Quaternion.identity);
            Manager.SlotDeTorre.Add(NovoSlot);
        }
    }
}
