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
    public float speed = 5f;
    private Vector2 moveInput;
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
    }

    public void Atirando(InputAction.CallbackContext context)
    {
        if (Time.timeScale >= 1 && canFire)
        {
            if (!context.performed || EventSystem.current.IsPointerOverGameObject()) return;
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
