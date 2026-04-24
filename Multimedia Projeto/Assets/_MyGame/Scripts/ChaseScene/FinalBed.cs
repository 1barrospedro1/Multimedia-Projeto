using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;          

public class FinalBed : MonoBehaviour, IInteractable
{
    [Header("UI & Transition")]
    public GameObject winScreen; 
    public string mainMenuScene = "MainMenu"; // Type your exact Main Menu scene name here
    public float timeToShowScreen = 4.0f; // How long the win screen stays up

    [Header("Audio (Optional)")]
    public AudioClip hideSound; // Add a blanket rustling sound if you have one!

    private bool isEscaped = false;

    private void Start()
    {
        // Ensure the win screen is hidden when the level starts
        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }
    }

    public void Interact()
    {
        // If we already clicked it, don't let us click it again
        if (isEscaped) return;

        isEscaped = true;

        if (hideSound != null) AudioSource.PlayClipAtPoint(hideSound, transform.position);
        
        // Start the win sequence!
        StartCoroutine(WinSequence());
    }

    IEnumerator WinSequence()
    {
        // 1. Freeze time! This stops the Mimic instantly right behind you.
        Time.timeScale = 0f;

        // 2. Turn on the "Escaped Successfully" UI Canvas
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }

        // 3. Wait for a few seconds (We MUST use Realtime since we set timeScale to 0!)
        yield return new WaitForSecondsRealtime(timeToShowScreen);

        // 4. Unfreeze time and load the Main Menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public string GetInteractPrompt()
    {
        // What the player sees when they look at the bed
        return "<size=80%><sprite index=0> Escape this nightmare</size>";
    }
}