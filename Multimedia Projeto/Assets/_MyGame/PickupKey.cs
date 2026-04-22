using UnityEngine;

public class PickupKey : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    public AudioClip pickupSound; 

    public void Interact()
    {
        playerInventory.hasRustyKey = true;
        
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
        
        gameObject.SetActive(false); 
    }

    public string GetInteractPrompt()
    {
        return "<size=80%><sprite index=0> Pick up Key</size>";
    }
}