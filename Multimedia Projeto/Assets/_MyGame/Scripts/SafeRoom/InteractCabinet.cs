using UnityEngine;

public class InteractCabinet : MonoBehaviour, IInteractable
{
    [Header("Visuals")]
    public GameObject closedCabinetDoor;
    public GameObject openCabinetDoor;
    public GameObject scaryHeadAndKey; // The object we want to reveal!

    [Header("Audio")]
    public AudioClip scareSound;
    [Range(0f, 1f)] public float soundVolume = 1f;

    private bool hasOpened = false;

    public void Interact()
    {
        if (!hasOpened)
        {
            hasOpened = true;

            // Swap the doors
            if (closedCabinetDoor != null) closedCabinetDoor.SetActive(false);
            if (openCabinetDoor != null) openCabinetDoor.SetActive(true);
            
            // Reveal the head and key
            if (scaryHeadAndKey != null) scaryHeadAndKey.SetActive(true);

            // Play the jumpscare sound
            if (scareSound != null) AudioSource.PlayClipAtPoint(scareSound, transform.position, soundVolume);

            // Turn off this interactable so the player can't click it again
            gameObject.SetActive(false); 
        }
    }

    public string GetInteractPrompt()
    {
        return "<size=80%><sprite index=0> Open Cabinet</size>";
    }
}