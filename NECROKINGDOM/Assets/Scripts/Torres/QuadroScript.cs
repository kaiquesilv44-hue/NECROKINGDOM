using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class QuadroScript : MonoBehaviour
{
    public GameObject obj;
    private Collider2D meuColisor;
    private Camera cam;
    private int Custo;
    LevelManagerScript Manager;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if(obj != null)
        {
            TorreScript Defesa = obj.GetComponent<TorreScript>();
            if(Defesa != null)
            {
                Custo = Defesa.Custo;
            }
            ArmadilhaScript defesa = obj.GetComponent<ArmadilhaScript>();
            if(defesa != null)
            {
                Custo = defesa.Custo;
            }
        }

        Manager = FindAnyObjectByType<LevelManagerScript>();
        meuColisor = GetComponent<Collider2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cam == null) cam = Camera.main;

            Vector3 mousePosMundo = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePosMundo.x, mousePosMundo.y);

            if (meuColisor != null && meuColisor.OverlapPoint(mousePos2D))
            {
                gerar();
            }
        }
    }

    private void gerar()
    {
        if (Manager.Almas >= Custo)
        {
            Manager.Almas -= Custo;
            Instantiate(obj, transform.position, Quaternion.identity);
        }
        else
        {
            sr.color = Color.red;
            StartCoroutine(VoltarCor());

        }
    }
    IEnumerator VoltarCor()
    {
        yield return new WaitForSeconds(0.5f);
        sr.color = Color.white;
    }
}
