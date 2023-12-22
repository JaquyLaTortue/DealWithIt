using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] int range = 5;
    [SerializeField] LayerMask interactableLayer;

    RaycastHit hit;
    public void Open(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, interactableLayer))
        {
            if (hit.collider.gameObject.GetComponent<Animator>())
            {
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Open");
            }
        }
    }

    public void Close(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, interactableLayer))
        {
            if (hit.collider.gameObject.GetComponent<Animator>())
            {
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Close");
            }
        }
    }
}
