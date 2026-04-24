using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathVolume : MonoBehaviour
{
    [Header("Game Over Settings")]
    public GameObject gameOverScreen;
    public float timeBeforeRestart = 2.5f;

    private bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the thing falling into the box is the Player
        if (other.CompareTag("Player") && !isDead)
        {
            StartCoroutine(FallDeathSequence());
        }
    }

    IEnumerator FallDeathSequence()
    {
        isDead = true;

        // 1. Freeze time so they stop falling mid-air
        Time.timeScale = 0f;

        // 2. Turn on the Game Over UI
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // 3. Wait in REAL time
        yield return new WaitForSecondsRealtime(timeBeforeRestart);

        // 4. Unfreeze time and reload the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}