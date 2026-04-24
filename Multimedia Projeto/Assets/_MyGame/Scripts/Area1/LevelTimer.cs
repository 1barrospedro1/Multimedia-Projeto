using UnityEngine;
using TMPro; // We need this to update the text!
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeLimitSeconds = 120f; 
    public TextMeshProUGUI timerTextUI;   

    [Header("Game Over Settings")]
    public GameObject gameOverScreen;
    public float timeBeforeRestart = 2.5f;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // If there is still time on the clock, count down
        if (timeLimitSeconds > 0)
        {
            timeLimitSeconds -= Time.deltaTime; // Time.deltaTime counts down in real seconds
            UpdateTimerDisplay();
        }
        else
        {
            // Time ran out!
            timeLimitSeconds = 0;
            StartCoroutine(TimeOutSequence());
        }
    }

    void UpdateTimerDisplay()
    {
        // If you attached a UI text object, update it to look like a digital clock (02:00)
        if (timerTextUI != null)
        {
            int minutes = Mathf.FloorToInt(timeLimitSeconds / 60);
            int seconds = Mathf.FloorToInt(timeLimitSeconds % 60);
            timerTextUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    IEnumerator TimeOutSequence()
    {
        isGameOver = true;

        // 1. Freeze the player and all physics
        Time.timeScale = 0f;

        // 2. Turn on the Game Over Canvas
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // 3. Wait in real-world time
        yield return new WaitForSecondsRealtime(timeBeforeRestart);

        // 4. Unfreeze time and restart Nightmare1
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}