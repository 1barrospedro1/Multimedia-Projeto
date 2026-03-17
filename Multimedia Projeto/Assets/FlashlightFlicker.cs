using System.Collections;
using UnityEngine;

public class FlashlightFlicker : MonoBehaviour
{
    [Header("Light Reference")]
    public Light flashlight;

    [Header("Flicker Timers")]
    [Tooltip("Minimum time between flickers")]
    public float minWaitTime = 0.5f;
    [Tooltip("Maximum time between flickers")]
    public float maxWaitTime = 3.0f;

    private float defaultIntensity;

    void Start()
    {
        // Save the bright intensity you set up earlier so we can return to it
        defaultIntensity = flashlight.intensity;
        
        // Kick off the infinite flickering loop when the game starts
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        // This 'while(true)' creates an infinite loop, but because it's a Coroutine, 
        // it won't freeze your game. It just runs in the background forever!
        while (true)
        {
            // 1. Wait for a random amount of time
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            // 2. Only perform the flicker if the player actually has the flashlight turned ON
            if (flashlight.enabled)
            {
                // Instantly drop the intensity to something very low to simulate a power dip
                flashlight.intensity = Random.Range(0f, defaultIntensity * 0.2f);
                
                // Wait a tiny fraction of a second (the actual visual "flicker")
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                
                // Snap the brightness right back to normal
                flashlight.intensity = defaultIntensity;
            }
        }
    }
}