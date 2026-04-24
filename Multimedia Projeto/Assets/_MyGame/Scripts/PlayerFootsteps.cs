using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [Header("Footstep Sounds")]
    public AudioClip normalStep;
    public AudioClip ventStep;
    public AudioClip waterStep;

    [Header("Settings")]
    public float stepInterval = 0.5f; // How fast you step (lower = faster)
    [Range(0f, 1f)] public float volume = 0.6f;

    private float stepTimer;
    private AudioSource audioSource;

    void Start()
    {
        // Automatically grab an AudioSource, or create one if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) 
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        // 1. Check if the player is pressing W, A, S, or D
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            // 2. When the timer hits zero, play a sound
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = stepInterval; // Reset the timer
            }
        }
        else
        {
            // Reset timer so the first step is instant when you start moving again
            stepTimer = 0f; 
        }
    }

    void PlayFootstepSound()
    {
        AudioClip clipToPlay = normalStep; // Default to normal shoes on floor

        // 3. Shoot an invisible laser down to check what floor we are touching
        // (The '2.0f' is the distance. If it doesn't detect the floor, try increasing this to 3.0f)
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2.0f))
        {
            if (hit.collider.CompareTag("Water"))
            {
                clipToPlay = waterStep;
            }
            else if (hit.collider.CompareTag("Vent"))
            {
                clipToPlay = ventStep;
            }
        }

        // 4. Play the sound!
        if (clipToPlay != null)
        {
            // This slightly randomizes the pitch so it sounds like real walking, not a robot!
            audioSource.pitch = Random.Range(0.85f, 1.15f); 
            audioSource.PlayOneShot(clipToPlay, volume);
        }
    }
}