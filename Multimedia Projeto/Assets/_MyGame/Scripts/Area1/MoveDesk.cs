using UnityEngine;

public class MoveDesk : MonoBehaviour, IInteractable
{
    [Header("Connections")]
    public PlayerInventory playerInventory; 
    public Transform targetLocation; 
    public AudioClip slideSound; 
    [Range(0f, 1f)] 
    public float soundVolume = 1.0f; 
    
    [Header("Text Prompts")]
    public string observationText = "<size=80%>There's a weird vent behind the desk...</size>";
    public string pushText = "<size=80%><sprite index=0> Push Desk</size>";
    
    private bool hasMoved = false;

    public void Interact()
    {
        // Only let them push if puzzle is done AND it hasn't been moved yet
        if (playerInventory.paintingPlaced && !hasMoved)
        {
            // Play the sliding sound exactly where the desk is currently located, at your chosen volume!
            if (slideSound != null)
            {
                AudioSource.PlayClipAtPoint(slideSound, transform.position, soundVolume);
            }

            // Move the desk
            transform.position = targetLocation.position;
            transform.rotation = targetLocation.rotation;
            
            hasMoved = true;
            GetComponent<Collider>().enabled = false; // Disable interaction
        }
    }

    public string GetInteractPrompt()
    {
        if (!hasMoved)
        {
            // If the puzzle is finished, show the push prompt
            if (playerInventory.paintingPlaced)
            {
                return pushText;
            }
            // If puzzle is NOT finished, just show the creepy observation
            else
            {
                return observationText;
            }
        }
        return ""; // Return nothing if already moved
    }
}