using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    [Header("Interaction Settings")]
    public string promptMessage = "Inspect Object";

    public void Interact()
    {
        Debug.Log("You just interacted with: " + gameObject.name);
    }

    public string GetInteractPrompt()
    {
        return promptMessage;
    }
}