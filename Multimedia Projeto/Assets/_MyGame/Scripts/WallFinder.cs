using UnityEngine;

public class WallFinder : MonoBehaviour
{
    // This fires the exact moment a Rigidbody crashes into a physical object
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("<color=orange>BUMPED INTO: </color>" + collision.gameObject.name);
    }

    // This fires continuously if you are pressed up against it
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("<color=yellow>STUCK AGAINST: </color>" + collision.gameObject.name);
    }
}