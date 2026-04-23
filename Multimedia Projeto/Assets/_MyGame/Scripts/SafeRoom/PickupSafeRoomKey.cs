using UnityEngine;

public class PickupSafeRoomKey : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    public AudioClip pickupSound; 
    [Range(0f, 1f)] public float soundVolume = 1f;

    public void Interact()
    {
        playerInventory.hasSafeRoomKey = true;
        
        if (pickupSound != null) AudioSource.PlayClipAtPoint(pickupSound, transform.position, soundVolume);
        
        gameObject.SetActive(false); // Hide the key once picked up
    }

    public string GetInteractPrompt()
    {
        return "<size=80%><sprite index=0> Pickup Key</size>";
    }
}