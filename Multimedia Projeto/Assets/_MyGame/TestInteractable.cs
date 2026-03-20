using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("You just interacted with: " + gameObject.name);
    }

    public string GetInteractPrompt()
    {
        return "Inspect Object";
    }
}