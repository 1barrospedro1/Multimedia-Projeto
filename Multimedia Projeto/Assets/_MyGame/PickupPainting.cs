using UnityEngine;

public class PickupPainting : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    public string promptText = "<sprite index=0>Pick up Painting";

    public void Interact()
    {
        // Tell the player's inventory they have it
        playerInventory.hasHorsePainting = true;
        
        // Make this painting disappear from the floor
        gameObject.SetActive(false); 
    }

    public string GetInteractPrompt()
    {
        return promptText;
    }
}