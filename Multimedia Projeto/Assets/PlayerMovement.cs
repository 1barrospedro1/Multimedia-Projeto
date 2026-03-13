using UnityEngine;
using UnityEngine.InputSystem; // We need this to use the new system!

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    [Header("Input Actions")]
    public InputAction moveAction; // This will show up in the Inspector

    private Rigidbody rb;
    private Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    // You have to explicitly turn Input Actions on and off in the new system
    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        // Read the Vector2 value (X and Y) directly from our input action
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = transform.right * movementInput.x + transform.forward * movementInput.y;

        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 targetVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
}