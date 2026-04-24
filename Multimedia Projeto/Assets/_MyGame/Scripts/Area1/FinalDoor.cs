using UnityEngine;
using UnityEngine.SceneManagement; // 1. Added this to manage scenes!
using System.Collections;          // 2. Added this for our timer delay!

public class FinalDoor : MonoBehaviour, IInteractable
{
    [Header("Connections")]
    public PlayerInventory playerInventory;
    public GameObject[] woodenPlanks; 
    
    [Header("Door Visuals")]
    public GameObject leftDoor;
    public GameObject rightDoor;
    
    [Header("Audio")]
    public AudioClip unlockSound;
    public AudioClip lockedSound;

    [Header("Scene Transition")]
    public string sceneToLoad = "ChaseScene"; // Type your exact scene name here
    public float delayBeforeLoad = 1.0f; // Gives the door time to open and sound to play

    private bool isEscaped = false;

    public void Interact()
    {
        if (ArePlanksInTheWay() || isEscaped) return;

        if (playerInventory.hasRustyKey)
        {
            isEscaped = true;
            if (unlockSound != null) AudioSource.PlayClipAtPoint(unlockSound, transform.position);
            
            // Turn off both doors
            if (leftDoor != null) leftDoor.SetActive(false);
            if (rightDoor != null) rightDoor.SetActive(false);
            
            // Turn off the visuals/colliders of this object, but keep the script running
            GetComponent<Collider>().enabled = false; 
            
            // Start the teleportation timer!
            StartCoroutine(TeleportSequence());
        }
        else
        {
            if (lockedSound != null) AudioSource.PlayClipAtPoint(lockedSound, transform.position);
        }
    }

    IEnumerator TeleportSequence()
    {
        // Wait for the sound to play and let the player realize the door is open
        yield return new WaitForSeconds(delayBeforeLoad);

        // Teleport to the Chase Scene!
        SceneManager.LoadScene(sceneToLoad);
    }

    public string GetInteractPrompt()
    {
        if (ArePlanksInTheWay())
        {
            return "<size=80%>It's boarded up tight.</size>";
        }

        if (playerInventory.hasRustyKey)
        {
            return "<size=80%><sprite index=0> Unlock Door & Escape!</size>";
        }
        else
        {
            return "<size=80%>It's locked. I need a key.</size>";
        }
    }

    private bool ArePlanksInTheWay()
    {
        foreach (GameObject plank in woodenPlanks)
        {
            if (plank != null && plank.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
}