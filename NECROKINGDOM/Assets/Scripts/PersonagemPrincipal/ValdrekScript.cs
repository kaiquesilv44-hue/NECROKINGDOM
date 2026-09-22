using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ValdrekScript : MonoBehaviour
{
    public GameObject Projetil;
    public GameObject LocalProjetil;
    public float speed = 3.8f;
    private Vector2 moveInput;
    private bool EstaNaUi = false;
    private bool canFire = true;
    public float FireCooldown = 0.5f;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += movement * speed * Time.deltaTime;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            EstaNaUi = true;
        }
        else
        {
            EstaNaUi = false;
        }
    }

    public void Atirando(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);


        if (Time.timeScale >= 1 && canFire)
        {
            if (!context.performed || EstaNaUi) return;
            if (hit.collider != null && hit.collider.CompareTag("UI")) return;
            Instantiate(Projetil, LocalProjetil.transform.position, LocalProjetil.transform.rotation);
            canFire = false;
            StartCoroutine(ResetFire());
        }
    }

    IEnumerator ResetFire()
    {
        yield return new WaitForSeconds(FireCooldown);
        canFire = true;
    }
}
