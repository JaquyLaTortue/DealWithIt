using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Windows;


public class Sneak : MonoBehaviour
{
    Rigidbody rb;
    public bool Crouch { get; private set; }

    public float sneak = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private InputAction _crouchAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sneaking(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;
        Debug.Log("ah");
        rb.position = Vector3.up / sneak;
        
    }
}
