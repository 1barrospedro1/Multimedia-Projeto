using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("Head Bob Settings")]
    public float bobSpeed = 14f; // How fast the camera bobs (matches footstep speed)
    public float bobAmount = 0.05f; // How high and low the camera goes
    
    [Tooltip("Drag your Player object here so we know how fast they are moving")]
    public Rigidbody playerRigidbody;

    private float defaultPosY = 0;
    private float timer = 0;

    void Start()
    {
        // Store the starting height of the camera (your eye level)
        defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        // Calculate the player's current speed, ignoring the Y axis so falling doesn't trigger head bob
        float speed = new Vector3(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z).magnitude;

        // If the player is moving on the ground
        if (speed > 0.1f)
        {
            // Increase the timer based on speed
            timer += Time.deltaTime * bobSpeed;
            
            // Apply the Sine wave math to the camera's local Y position
            transform.localPosition = new Vector3(
                transform.localPosition.x, 
                defaultPosY + Mathf.Sin(timer) * bobAmount, 
                transform.localPosition.z);
        }
        else
        {
            // If the player stops moving, smoothly return the camera back to the default eye level
            timer = 0;
            transform.localPosition = new Vector3(
                transform.localPosition.x, 
                Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobSpeed), 
                transform.localPosition.z);
        }
    }
}