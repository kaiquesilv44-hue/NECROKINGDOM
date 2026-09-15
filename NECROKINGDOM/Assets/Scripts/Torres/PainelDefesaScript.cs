using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelDefesaScript : MonoBehaviour
{
   private bool Recolhido = false;

    private void Update()
    {
        if (Recolhido)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-9.45f, 0, 0), Time.deltaTime * 5);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-8.25f, 0, 0), Time.deltaTime * 5);
        }
    }
    public void Recolher()
    {
        Recolhido = !Recolhido;
    }
}
