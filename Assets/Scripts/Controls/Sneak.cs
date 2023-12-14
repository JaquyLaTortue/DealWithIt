using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Sneak : MonoBehaviour
{
    Rigidbody rb;
    public bool Crouch { get; private set; }

    public float sneak = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnSneak(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {

            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - sneak, gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(1, sneak, 1);
        }
        else if (ctx.canceled)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
}
