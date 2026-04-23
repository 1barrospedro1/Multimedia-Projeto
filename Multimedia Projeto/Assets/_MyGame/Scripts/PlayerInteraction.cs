using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; 
using TMPro; 

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Camera playerCamera;
    public float interactDistance = 3f;

    [Header("UI Elements")]
    public Image crosshair;
    public TextMeshProUGUI promptText;

    public Color defaultCrosshairColor = Color.white; 
    public Color interactCrosshairColor = Color.red;

    [Header("Input Action")]
    public InputAction interactAction;

    private void OnEnable() => interactAction.Enable();
    private void OnDisable() => interactAction.Disable();

    void Update()
    {
        // 1. Reset UI to default every single frame
        crosshair.color = defaultCrosshairColor;
        promptText.text = "";

        // 2. Shoot the laser
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                // 3. We hit something interactive! Change the UI.
                crosshair.color = interactCrosshairColor; 
                promptText.text = interactable.GetInteractPrompt();

                // 4. Listen for the button press
                if (interactAction.WasPressedThisFrame())
                {
                    interactable.Interact();
                }
            }
        }
    }
}