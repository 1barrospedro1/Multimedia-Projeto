using UnityEngine;

public class PickupCrowbar : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;

    public void Interact()
    {
        // Tell the inventory we have it, then make the crowbar disappear from the floor
        playerInventory.hasCrowbar = true;
        gameObject.SetActive(false); 
    }

    public string GetInteractPrompt()
    {
        return "<size=80%><sprite index=0> Pick up Crowbar</size>";
    }
}