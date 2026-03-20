using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Camera playerCamera;
    public float interactDistance = 3f;

    [Header("Input Action")]
    public InputAction interactAction;

    private void OnEnable() => interactAction.Enable();
    private void OnDisable() => interactAction.Disable();

    void Update()
    {
        // 1. Create an invisible laser pointing out from the exact center of the camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // 2. If the laser hits something within our interact distance
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // 3. Check if the object we hit has a script that uses our IInteractable interface
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                // (Later we can put UI code here to show the "Press E" text on screen)

                // 4. If they press the button while looking at it, trigger the interaction
                if (interactAction.WasPressedThisFrame())
                {
                    interactable.Interact();
                }
            }
        }
    }
}