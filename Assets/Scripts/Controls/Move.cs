using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    //Define at wich speed the player moves
    [Header("Speed")]
    public float InitialSpeed;
    private float Speed;

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
    void Update()
    {
        //Vector3 moveDirection = new Vector3(_horizontalInout, 0, _verticalInput);
        //transform.Translate(moveDirection * (Speed * Time.deltaTime));
        
        _moveDirection = transform.forward * _verticalInput + transform.right * _horizontalInput;
        rb.AddForce(_moveDirection.normalized * Speed * 10f, ForceMode.Force);

    }
}