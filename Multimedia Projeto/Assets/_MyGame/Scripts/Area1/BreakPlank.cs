using UnityEngine;

public class BreakPlank : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    
    [Header("Audio Settings")]
    public AudioClip breakSound; 
    [Range(0f, 1f)] 
    public float soundVolume = 1.0f; 

    public void Interact()
    {
        // Only let them interact if they actually have the crowbar
        if (playerInventory.hasCrowbar)
        {
            // Play the breaking sound right at this exact position, at your chosen volume!
            if (breakSound != null)
            {
                AudioSource.PlayClipAtPoint(breakSound, transform.position, soundVolume);
            }

            // "Break" the plank by hiding it
            gameObject.SetActive(false);
        }
    }

    public string GetInteractPrompt()
    {
        if (playerInventory.hasCrowbar)
        {
            return "<size=80%><sprite index=0> Break plank</size>";
        }
        else
        {
            return "<size=80%>I need a tool for this.</size>";
        }
    }
}