using UnityEngine;
using UnityEngine.SceneManagement; // <--- We need this to change levels!

public class SafeRoomDoor : MonoBehaviour, IInteractable
{
    [Header("Connections")]
    public PlayerInventory playerInventory;
    
    // Instead of a Transform, we just type the name of the Scene!
    [Header("Level Loading")]
    public string sceneToLoad = "MainRoomScene"; 

    [Header("Audio")]
    public AudioClip lockedSound;
    public AudioClip unlockAndOpenSound;

    public void Interact()
    {
        if (playerInventory.hasSafeRoomKey)
        {
            if (unlockAndOpenSound != null) AudioSource.PlayClipAtPoint(unlockAndOpenSound, transform.position);

            // --- LOAD THE NEW LEVEL ---
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            if (lockedSound != null) AudioSource.PlayClipAtPoint(lockedSound, transform.position);
        }
    }

    public string GetInteractPrompt()
    {
        if (playerInventory.hasSafeRoomKey)
        {
            return "<size=80%><sprite index=0> Open door</size>";
        }
        else
        {
            return "<size=80%>It's locked tight.</size>";
        }
    }
}