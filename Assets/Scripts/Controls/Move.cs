using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _moveSpeed = 5f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 inputDirection = new Vector3()
        {
            x = Input.GetAxis("Horizontal"),
            y = 0,
            z = Input.GetAxis("Vertical")
        };

        Vector3 velocity = inputDirection * _moveSpeed * Time.deltaTime;
        _characterController.Move(velocity);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
}
