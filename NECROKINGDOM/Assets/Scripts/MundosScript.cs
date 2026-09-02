using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MundosScript : MonoBehaviour
{
    public int Mundo;
    public string MundoName;

    public void PlayButton()
    {
        if(Mundo == 2)
        {
            SceneManager.LoadScene(MundoName);
        }
    }

    public void ClickR()
    {
        int MundoAnterior = Mundo;
        Mundo++;

        if (Mundo > 3)
        {
            Mundo = 1;
        }


        if (Mundo == 1)
        {
            StartCoroutine(Mundo1(MundoAnterior));
        }
        else if (Mundo == 2)
        {
            StartCoroutine(Mundo2());
        }
        else if (Mundo == 3)
        {
            StartCoroutine(Mundo3(MundoAnterior));
        }

    }

    public void ClickL()
    {
        int MundoAnterior = Mundo;
        Mundo--;


        if (Mundo < 1)
        {
            Mundo = 3;
        }

        if (Mundo == 1)
        {
            StartCoroutine(Mundo1(MundoAnterior));
        }
        else if (Mundo == 2)
        {
            StartCoroutine(Mundo2());
        }
        else if (Mundo == 3)
        {
            StartCoroutine(Mundo3(MundoAnterior));
        }
    }

    IEnumerator Mundo1(int MundoAnterior)
    {
        float Velo = 6f;
        if (MundoAnterior == 3)
        {
            Velo = 12f;
        }
        Vector3 Scale = new Vector3(3f, 4.8f, 1f);
        Vector3 Position = new Vector3(-5.5f, 1f, 0f);

        while (transform.localScale != Scale || transform.position != Position)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Scale, 1f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Position, Velo * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Mundo2()
    {
        float Velo = 6f;
        Vector3 Scale = new Vector3(3.5f, 5.5f, 1f);
        Vector3 Position = new Vector3(0f, 0f, 0f);

        while (transform.localScale != Scale || transform.position != Position)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Scale, 1f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Position, Velo * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Mundo3(int MundoAnterior)
    {
        float Velo = 6f;
        if(MundoAnterior == 1)
        {
            Velo = 12f;
        }
        Vector3 Scale = new Vector3(3f, 4.8f, 1f);
        Vector3 Position = new Vector3(5.5f, 1f, 0f);

        while (transform.localScale != Scale || transform.position != Position)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Scale, 1f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Position, Velo * Time.deltaTime);
            yield return null;
        }
    }
}
