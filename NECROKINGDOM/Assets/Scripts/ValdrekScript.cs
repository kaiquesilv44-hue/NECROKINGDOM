using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ValdrekScript : MonoBehaviour
{
    public GameObject Projetil;
    public GameObject LocalProjetil;
    public float speed = 5f;
    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += movement * speed * Time.deltaTime;
    }

    public void Atirando(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Instantiate(Projetil, LocalProjetil.transform.position, LocalProjetil.transform.rotation);
    }
}
