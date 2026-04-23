using UnityEngine;

public class FinalDoor : MonoBehaviour, IInteractable
{
    [Header("Connections")]
    public PlayerInventory playerInventory;
    public GameObject[] woodenPlanks; 
    
    [Header("Door Visuals")]
    public GameObject leftDoor;
    public GameObject rightDoor;
    
    [Header("Audio")]
    public AudioClip unlockSound;
    public AudioClip lockedSound;

    private bool isEscaped = false;

    public void Interact()
    {
        if (ArePlanksInTheWay() || isEscaped) return;

        if (playerInventory.hasRustyKey)
        {
            isEscaped = true;
            if (unlockSound != null) AudioSource.PlayClipAtPoint(unlockSound, transform.position);
            
            // Turn off both doors
            if (leftDoor != null) leftDoor.SetActive(false);
            if (rightDoor != null) rightDoor.SetActive(false);
            
            // Turn off this invisible interaction box so they can't click it anymore
            gameObject.SetActive(false);
            
            Debug.Log("<color=yellow>!!! YOU ESCAPED !!!</color>");
        }
        else
        {
            if (lockedSound != null) AudioSource.PlayClipAtPoint(lockedSound, transform.position);
        }
    }

    public string GetInteractPrompt()
    {
        if (ArePlanksInTheWay())
        {
            return "<size=80%>It's boarded up tight.</size>";
        }

        if (playerInventory.hasRustyKey)
        {
            return "<size=80%><sprite index=0> Unlock Door & Escape!</size>";
        }
        else
        {
            return "<size=80%>It's locked. I need a key.</size>";
        }
    }

    private bool ArePlanksInTheWay()
    {
        foreach (GameObject plank in woodenPlanks)
        {
            if (plank != null && plank.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
}