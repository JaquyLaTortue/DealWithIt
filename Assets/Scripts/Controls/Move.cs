using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    //Define at wich speed the player moves
    [Header("Speed")]
    public float InitialSpeed;
    private float Speed;

    public float groundDrag;

    public float airMultiplier;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisGround;
    bool grounded;

    [Header("Axis")]
    private float _horizontalInput;
    private float _verticalInput;
    Vector3 _moveDirection;

    [Header("References")]
    private Rigidbody rb;
 
    //Stores the value of the move input

    private void Start()
    {
        Speed = InitialSpeed;
        rb = GetComponent<Rigidbody>();
    }

    public void SetSneakSpeed(float desiredSpeed)
    {
        Speed = desiredSpeed;
    }


    //gets the value of the move input
    public void OnMove(InputAction.CallbackContext context)
    {
        _horizontalInput = context.ReadValue<Vector2>().x;
        _verticalInput = context.ReadValue<Vector2>().y;
    }

    //will update the player position by the move input
    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisGround);

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        //Vector3 moveDirection = new Vector3(_horizontalInout, 0, _verticalInput);
        //transform.Translate(moveDirection * (Speed * Time.deltaTime));

        _moveDirection = transform.forward * _verticalInput + transform.right * _horizontalInput;
        if (grounded)
        {
            rb.AddForce(_moveDirection.normalized * Speed * 1f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(_moveDirection.normalized * Speed * 1f * airMultiplier, ForceMode.Force);
        }
        

    }

}