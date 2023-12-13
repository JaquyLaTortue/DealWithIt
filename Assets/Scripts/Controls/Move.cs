using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    //Define at wich speed the player moves
    public float speed;

    //Stores the value of the move input
    Vector3 _moveDirection;

    //gets the value of the move input
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    //will update the player position by the move input
    void Update()
    {
        Vector3 moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y);
        transform.Translate(moveDirection * (speed * Time.deltaTime));

    }
}