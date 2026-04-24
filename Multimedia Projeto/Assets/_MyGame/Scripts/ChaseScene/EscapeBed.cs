using UnityEngine;

public class EscapeBed : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject interactPrompt; // "Press E to Hide" text
    public GameObject winScreen;      // The "You Survived" screen

    private bool canEscape = false;

    void Start()
    {
        // Make sure UI is hidden at the start
        if (interactPrompt != null) interactPrompt.SetActive(false);
        if (winScreen != null) winScreen.SetActive(false);
    }

    void Update()
    {
        // If the player is in the zone and presses 'E'
        if (canEscape && Input.GetKeyDown(KeyCode.E))
        {
            WinGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the player steps into the trigger box
        if (other.CompareTag("Player"))
        {
            canEscape = true;
            if (interactPrompt != null) interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player runs away from the bed
        if (other.CompareTag("Player"))
        {
            canEscape = false;
            if (interactPrompt != null) interactPrompt.SetActive(false);
        }
    }

    void WinGame()
    {
        // Freeze time so the monster instantly stops!
        Time.timeScale = 0f;
        
        // Hide the 'E' prompt and show the Win Screen
        if (interactPrompt != null) interactPrompt.SetActive(false);
        if (winScreen != null) winScreen.SetActive(true);
    }
}