using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight Component")]
    [Tooltip("Drag the Light component here")]
    public Light spotlight;
    public AudioSource clickSound;

    [Header("Input Settings")]
    public InputAction toggleAction;

    private void OnEnable()
    {
        toggleAction.Enable();
    }

    private void OnDisable()
    {
        toggleAction.Disable();
    }

    void Update()
    {
        // Check if the button was pressed during this specific frame
        if (toggleAction.WasPressedThisFrame())
        {
            // This flips the boolean. If it's true, it becomes false. If false, true
            spotlight.enabled = !spotlight.enabled;
            if (clickSound != null)
            {
                clickSound.Play(); 
            }
        }
    }
}