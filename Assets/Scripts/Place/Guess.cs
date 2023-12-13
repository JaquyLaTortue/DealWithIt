using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guess : MonoBehaviour
{
    [SerializeField] LayerMask Props;
    [SerializeField] LayerMask Target;

    RaycastHit hit;

    public void OnGuess(InputAction.CallbackContext ctx)
    {
        if(!ctx.started) return;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Target))
        {
            Debug.Log("You found the target");
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Props))
        {
            Debug.Log("You found a prop");
        }
        else
        {
            Debug.Log("You found nothing");
        }
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Target))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.blue);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15, Props))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.black);
        }


    }
}
