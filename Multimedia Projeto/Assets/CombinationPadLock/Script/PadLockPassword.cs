using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;
    public int[] _numberPassword = {0,0,0,0};
    
    [Header("Custom Win Events")]
    public InteractPadlock lockManager; 
    // --- CHANGED THESE TWO LINES ---
    public GameObject closedCabinetDoor; // Hide closed door
    public GameObject openCabinetDoor;   // Show open door
    
    public AudioClip unlockSound;
    [Range(0f, 1f)] 
    public float unlockSoundVolume = 0.5f;       
    public AudioClip wrongCodeSound;    
    [Range(0f, 1f)] 
    public float WrongSoundVolume = 0.5f;

    private void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
    }

    public void Password()
    {
        if (lockManager == null || !lockManager.isInteracting)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log($"The lock currently reads: {_moveRull._numberArray[0]} - {_moveRull._numberArray[1]} - {_moveRull._numberArray[2]} - {_moveRull._numberArray[3]}");

            if (_moveRull._numberArray.SequenceEqual(_numberPassword))
            {
                // --- SUCCESS ---
                for (int i = 0; i < _moveRull._rullers.Count; i++)
                {
                    _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                    _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
                }

                if (unlockSound != null) AudioSource.PlayClipAtPoint(unlockSound, transform.position, unlockSoundVolume);
                if (lockManager != null) lockManager.ExitLock();
                
                // --- THE DOOR SWAP ---
                if (closedCabinetDoor != null) closedCabinetDoor.SetActive(false);
                if (openCabinetDoor != null) openCabinetDoor.SetActive(true);
                
                gameObject.SetActive(false); // Hide the lock
            }
            else
            {
                // --- FAILED GUESS ---
                Debug.Log("Wrong Code!");
                if (wrongCodeSound != null) AudioSource.PlayClipAtPoint(wrongCodeSound, transform.position, WrongSoundVolume);
            }
        }
    }
}