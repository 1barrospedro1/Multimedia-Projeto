using UnityEngine;

public class StreetlightTrigger : MonoBehaviour
{
    [Header("The Lights for this Zone")]
    public GameObject[] lightsToTurnOn; 

    [Header("Optional Audio")]
    public AudioClip lightBuzzSound;
    [Range(0f, 1f)] public float soundVolume = 0.8f;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if it's the Player and if we haven't already turned these on
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            // 2. Turn on every light we assigned to this trigger
            foreach (GameObject lightObj in lightsToTurnOn)
            {
                if (lightObj != null)
                {
                    lightObj.SetActive(true);
                }
            }

            // 3. Play a spooky electric snap/buzz sound if you have one!
            if (lightBuzzSound != null)
            {
                AudioSource.PlayClipAtPoint(lightBuzzSound, transform.position, soundVolume);
            }
        }
    }
}