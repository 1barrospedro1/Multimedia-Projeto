using System.Collections; // We need this to use timers (Coroutines)
using UnityEngine;
using UnityEngine.AI;
using MimicSpace;
using UnityEngine.SceneManagement; 

public class MimicAI : MonoBehaviour
{
    [Header("Target")]
    public Transform player;
    
    [Header("Catch Settings")]
    public float catchDistance = 1.5f;
    public GameObject gameOverScreen; // We will drag our UI Canvas here
    public float timeBeforeRestart = 2.5f; // How many seconds the screen stays up

    private NavMeshAgent agent;
    private Mimic myMimic;
    private bool isCaught = false; // This stops the timer from triggering 100 times a second

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myMimic = GetComponent<Mimic>();

        // Make sure the screen is hidden when the level starts
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        // Only chase if we haven't caught the player yet
        if (player != null && !isCaught)
        {
            agent.SetDestination(player.position);
            myMimic.velocity = agent.velocity;

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= catchDistance)
            {
                // Start the Game Over timer!
                StartCoroutine(CatchPlayerSequence());
            }
        }
    }

    IEnumerator CatchPlayerSequence()
    {
        isCaught = true; 

        // 1. FREEZE TIME! This stops the player, the monster, and all physics.
        Time.timeScale = 0f;

        // 2. Turn on the Game Over UI
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // 3. Wait in REAL time (since game time is currently at 0)
        yield return new WaitForSecondsRealtime(timeBeforeRestart);

        // 4. UNFREEZE time and reload the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}