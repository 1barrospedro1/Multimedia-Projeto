using UnityEngine;

public class BreakPlank : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;

    public void Interact()
    {
        // Only let them interact if they actually have the crowbar
        if (playerInventory.hasCrowbar)
        {
            // "Break" the plank by hiding it
            gameObject.SetActive(false);
        }
    }

    public string GetInteractPrompt()
    {
        if (playerInventory.hasCrowbar)
        {
            return "<size=80%><sprite index=0> Pry off plank</size>";
        }
        else
        {
            // What the player sees if they try to click it with empty hands
            return "It's nailed shut tight. I need a tool for this.";
        }
    }
}