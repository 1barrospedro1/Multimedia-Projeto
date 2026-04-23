using UnityEngine;

public class BreakPlank : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    public AudioClip breakSound; 

    public void Interact()
    {
        // Only let them interact if they actually have the crowbar
        if (playerInventory.hasCrowbar)
        {
            // Play the breaking sound right at this exact position
            if (breakSound != null)
            {
                AudioSource.PlayClipAtPoint(breakSound, transform.position);
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