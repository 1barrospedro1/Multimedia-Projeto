using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float jumpForce = 5f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    [Header("Input Actions")]
    public InputAction moveAction;
    public InputAction jumpAction;
    public InputAction crouchAction;

    private Rigidbody rb;
    private Vector2 movementInput;
    private float currentSpeed;
    
    // Variables for crouching
    private Vector3 standingScale;
    private Vector3 crouchScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        currentSpeed = moveSpeed;
        standingScale = transform.localScale;
        // Halve the Y scale for crouching
        crouchScale = new Vector3(standingScale.x, standingScale.y * 0.5f, standingScale.z); 
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        crouchAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        crouchAction.Disable();
    }

    void Update()
    {
        // 1. Ground Check: Creates an invisible sphere at the player's feet to check for the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // 2. Read Movement Input
        movementInput = moveAction.ReadValue<Vector2>();

        // 3. Jump Logic
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            // Reset Y velocity first so jumps are always exactly the same height
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        // 4. Crouch Logic
        if (crouchAction.IsPressed())
        {
            transform.localScale = crouchScale;
            currentSpeed = crouchSpeed;
        }
        else
        {
            transform.localScale = standingScale;
            currentSpeed = moveSpeed;
        }
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

        Vector3 targetVelocity = moveDirection * currentSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
}