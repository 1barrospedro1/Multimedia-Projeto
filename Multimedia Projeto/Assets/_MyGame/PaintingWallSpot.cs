using UnityEngine;

public class PaintingWallSpot : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    public GameObject finishedPaintingVisual; // The completed painting on the wall
    public GameObject ventCover;
    
    public void Interact()
    {
        // Only allow interaction IF the player is holding the painting
        if (playerInventory.hasHorsePainting)
        {
            playerInventory.hasHorsePainting = false; // Remove it from inventory
            playerInventory.paintingPlaced = true;    // Tell the inventory the puzzle is officially complete!
            finishedPaintingVisual.SetActive(true);   // Reveal the painting on the wall
            if (ventCover != null)
            {
                ventCover.SetActive(false);
            }
            gameObject.SetActive(false);              // Hide this gray box
        }
    }

    public string GetInteractPrompt()
    {
        // The prompt changes depending on if you have the item!
        if (playerInventory.hasHorsePainting)
        {
            return "<size=80%><sprite index=0>Place Painting</size>";
        }
        else
        {
            return "<nobr><size=80%>Something is missing here...</size></nobr>"; 
        }
    }
}