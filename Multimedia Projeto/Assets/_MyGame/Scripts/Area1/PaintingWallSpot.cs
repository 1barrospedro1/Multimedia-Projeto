using UnityEngine;

public class PaintingWallSpot : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    public GameObject finishedPaintingVisual; 
    public GameObject ventCover; 
    
    [Header("Audio Settings")]
    public AudioClip ventOpenSound; 
    [Range(0f, 1f)] 
    public float soundVolume = 1.0f; 
    
    public void Interact()
    {
        if (playerInventory.hasHorsePainting)
        {
            playerInventory.hasHorsePainting = false; 
            playerInventory.paintingPlaced = true; 
            
            finishedPaintingVisual.SetActive(true);   
            
            // Pop the vent open instantly from across the room!
            if (ventCover != null)
            {
                // Play the sound physically over at the vent's location, at your chosen volume!
                if (ventOpenSound != null)
                {
                    AudioSource.PlayClipAtPoint(ventOpenSound, ventCover.transform.position, soundVolume);
                }
                
                ventCover.SetActive(false);
            }

            // The invisible wall spot turns itself off so you can't click it again
            gameObject.SetActive(false);              
        }
    }

    public string GetInteractPrompt()
    {
        if (playerInventory.hasHorsePainting)
        {
            return "<size=80%><sprite index=0> Place Painting</size>";
        }
        else
        {
            return "<size=80%>Something is missing here...</size>"; 
        }
    }
}