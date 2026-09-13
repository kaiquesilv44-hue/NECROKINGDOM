using UnityEngine;

public class CajadoScript : MonoBehaviour
{
    private Camera cam;
    private Vector3 MousePos;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale >= 1)
        {
            MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotaion = MousePos - transform.position;

            float angle = Mathf.Atan2(rotaion.y, rotaion.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
