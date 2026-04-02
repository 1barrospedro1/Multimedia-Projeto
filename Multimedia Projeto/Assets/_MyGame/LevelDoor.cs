using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    public string promptMessage = "Enter the Nightmare";
    public string sceneToLoad = "Nightmare1";

    public void Interact()
    {
        Debug.Log("Teleporting to " + sceneToLoad + "...");
        SceneManager.LoadScene(sceneToLoad); 
    }

    public string GetInteractPrompt()
    {
        return promptMessage;
    }
}