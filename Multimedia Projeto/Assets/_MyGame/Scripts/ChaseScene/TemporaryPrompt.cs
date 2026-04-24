using UnityEngine;
using System.Collections; // Needed for the timer

public class TemporaryPrompt : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject promptText; // The text we want to hide
    public float displayTime = 3.0f; // How many seconds it stays on screen

    void Start()
    {
        // Make sure the text is turned ON when the scene first loads
        if (promptText != null)
        {
            promptText.SetActive(true);
            
            // Start the countdown timer to hide it
            StartCoroutine(HidePromptRoutine());
        }
    }

    IEnumerator HidePromptRoutine()
    {
        // Wait for the specified amount of seconds
        yield return new WaitForSeconds(displayTime);

        // Turn the text OFF
        if (promptText != null)
        {
            promptText.SetActive(false);
        }
    }
}