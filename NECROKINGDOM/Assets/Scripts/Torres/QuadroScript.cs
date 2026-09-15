using UnityEngine;
using UnityEngine.EventSystems;

public class QuadroScript : MonoBehaviour
{
    public GameObject Torre;

    private void OnMouseDown()
    {
        Instantiate(Torre, transform.position, Quaternion.identity);
    }

}
