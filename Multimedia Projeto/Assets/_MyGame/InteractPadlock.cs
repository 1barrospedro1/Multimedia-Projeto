using UnityEngine;

public class InteractPadlock : MonoBehaviour, IInteractable
{
    [Header("Lock Scripts")]
    public MoveRuller lockMovementScript; 

    [Header("Player Scripts to Freeze")]
    public MonoBehaviour playerMovement; 
    public MonoBehaviour mouseLook;      
    public Behaviour playerInputSystem;  

    [Header("Camera Zoom")]
    public Camera playerCamera; // Main Camera here
    public float zoomedFOV = 30f; // Lower number = more zoomed in
    private float originalFOV;

    // CHANGED TO PUBLIC: Now the password script can see if the player is zoomed in
    public bool isInteracting = false;

    public void Interact()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            
            // Turn ON the lock's WASD controls
            lockMovementScript.enabled = true; 
            
            // Turn OFF the player's controls
            if (playerMovement != null) playerMovement.enabled = false;    
            if (mouseLook != null) mouseLook.enabled = false;         
            if (playerInputSystem != null) playerInputSystem.enabled = false;

            // Zoom the camera in
            if (playerCamera != null)
            {
                originalFOV = playerCamera.fieldOfView;
                playerCamera.fieldOfView = zoomedFOV;
            }
        }
    }

    void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLock();
        }
    }

    public void ExitLock()
    {
        isInteracting = false;
        
        lockMovementScript.enabled = false; 
        
        if (playerMovement != null) playerMovement.enabled = true;      
        if (mouseLook != null) mouseLook.enabled = true;           
        if (playerInputSystem != null) playerInputSystem.enabled = true;

        // Zoom camera back out
        if (playerCamera != null) playerCamera.fieldOfView = originalFOV;
    }

    public string GetInteractPrompt()
    {
        if (!isInteracting)
        {
            return "<size=80%><sprite index=0> Inspect Lock</size>";
        }
        else
        {
            return "<color=white><sprite name=\"esc\"> Exit  <sprite name=\"keyboard-wasd\"> Spin  <sprite index=0> Confirm</color>";
        }
    }
}