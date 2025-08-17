using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;
    private InputSystem_Actions actions;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        actions.Player.Enable();
    }

    private void OnDisable()
    {
        actions.Player.Disable();
    }

    void Update()
    {
        moveInput = actions.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Read the input value
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        // Move the player
        rb.linearVelocity = moveDirection * moveSpeed;
    }
}