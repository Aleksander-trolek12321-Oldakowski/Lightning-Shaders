using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementVector;
    PlayerInput playerInputActions;
    [SerializeField] private float speed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerInputActions = new PlayerInput();
        playerInputActions.Player.Move.performed += MovePerformed;
        playerInputActions.Player.Move.canceled += OnMoveCanceled;

        playerInputActions.Player.Enable();

    }

    public void MovePerformed(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        movementVector.x = input.x;
        movementVector.y = input.y;
        movementVector *= speed;
        rb.linearVelocity = movementVector;
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        movementVector = Vector2.zero;
        rb.linearVelocity = movementVector;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementVector;
    }
}
