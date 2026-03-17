using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("Head Bob Settings")]
    public float bobSpeed = 14f; 
    public float bobAmount = 0.05f; 
    
    [Header("References")]
    public Rigidbody playerRigidbody;
    // NEW: need a reference to the player movement script to check if the player is grounded
    public PlayerMovement playerMovement; 

    private float defaultPosY = 0;
    private float timer = 0;

    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        // Calculate the player's current speed
        float speed = new Vector3(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z).magnitude;

        // NEW: added "&& playerMovement.isGrounded" to this check
        if (speed > 0.1f && playerMovement.isGrounded)
        {
            timer += Time.deltaTime * bobSpeed;
            transform.localPosition = new Vector3(
                transform.localPosition.x, 
                defaultPosY + Mathf.Sin(timer) * bobAmount, 
                transform.localPosition.z);
        }
        else
        {
            timer = 0;
            transform.localPosition = new Vector3(
                transform.localPosition.x, 
                Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobSpeed), 
                transform.localPosition.z);
        }
    }
}