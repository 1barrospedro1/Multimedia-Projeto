using UnityEngine;

public class InteractTV : MonoBehaviour, IInteractable
{
    [Header("TV Components")]
    public GameObject tvLight;      // The TV light
    public GameObject clueScreen;   // For the clue
    
    [Header("Audio Settings")]
    public AudioClip turnOnSound;   // On sound
    public AudioClip turnOffSound;   // Off sound
    [Range(0f, 1f)] 
    public float soundVolume = 1.0f; 

    private bool isOn = false;

    public void Interact()
    {
        // If it's off, turn it on
        if (!isOn)
        {
            isOn = true;
            
            if (tvLight != null) tvLight.SetActive(true);
            if (clueScreen != null) clueScreen.SetActive(true);
            
            if (turnOnSound != null)
            {
                // Added soundVolume here!
                AudioSource.PlayClipAtPoint(turnOnSound, transform.position, soundVolume);
            }
        }
        else
        {
            isOn = false;
            if (tvLight != null) tvLight.SetActive(false);
            if (clueScreen != null) clueScreen.SetActive(false);

            if (turnOffSound != null)
            {
                // Added soundVolume here too!
                AudioSource.PlayClipAtPoint(turnOffSound, transform.position, soundVolume);
            }
        }
    }

    public string GetInteractPrompt()
    {
        if (!isOn)
        {
            return "<size=80%><sprite index=0> Turn On TV</size>";
        }
        else
        {
            return "<size=80%><sprite index=0> Turn Off TV</size>";
        }
    }
}