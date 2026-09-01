using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TorreScript : MonoBehaviour
{
    public GameObject TorreProjetil;
    public GameObject LocalTorreProjetil;
    private bool Cooldown = true;
    private float MenorDistancia = math.INFINITY;
    public Transform Alvo;
    public float CoolDown = 5f;


    private List<Transform> Inimigos = new List<Transform> ();

    private void Update()
    {
        Inimigos.RemoveAll(inimigo => inimigo == null);
        if (Inimigos.Count > 0 && Cooldown)
        {
            MenorDistancia = math.INFINITY;
            foreach(Transform t in Inimigos)
            {
                float distancia = Vector3.Distance(transform.position, t.position);
                if(distancia < MenorDistancia)
                {
                    MenorDistancia = distancia;
                    Alvo = t;
                }
            }
            GameObject proj = Instantiate(TorreProjetil, LocalTorreProjetil.transform.position, LocalTorreProjetil.transform.rotation);
            proj.GetComponent<ProjetilValdrekScript>().Alvo = Alvo;
            Cooldown = false;
            StartCoroutine(cooldown());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
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
}
