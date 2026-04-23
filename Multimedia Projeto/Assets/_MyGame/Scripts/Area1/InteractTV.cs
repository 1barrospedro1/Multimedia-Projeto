using UnityEngine;

public class InteractTV : MonoBehaviour, IInteractable
{
    [Header("TV Components")]
    public GameObject tvLight;      // The TV light
    public GameObject clueScreen;   // For the clue
    public AudioClip turnOnSound;   // On sound
    public AudioClip turnOffSound;   // Off sound

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
                AudioSource.PlayClipAtPoint(turnOnSound, transform.position);
            }
        }
        else
        {
            isOn = false;
            if (tvLight != null) tvLight.SetActive(false);
            if (clueScreen != null) clueScreen.SetActive(false);

            if (turnOffSound != null)
            {
                AudioSource.PlayClipAtPoint(turnOffSound, transform.position);
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