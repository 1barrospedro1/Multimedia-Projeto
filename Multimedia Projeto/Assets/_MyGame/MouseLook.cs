using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0.1f;
    public Transform playerBody;
    public InputAction lookAction;

    private float xRotation = 0f;
    private float yRotation = 0f; // NEW: We will explicitly track horizontal rotation now

    private void OnEnable()
    {
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        // Grab the player's starting Y rotation so we don't snap to a weird angle when the game starts
        yRotation = playerBody.eulerAngles.y; 
    }

    void Update()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        // 1. Calculate Up and Down (Camera)
        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 2. Calculate Left and Right (Player Body)
        yRotation += mouseX;
        
        // Force the exact rotation, completely bypassing the physics engine's interpolation guesswork!
        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}