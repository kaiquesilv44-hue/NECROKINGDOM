using UnityEngine;

public class ObjetivoScript : MonoBehaviour
{
    public GameObject Manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Manager.GetComponent<LevelManagerScript>().Vida--;
            Destroy(other.gameObject, 2f);
        }
    }
}
