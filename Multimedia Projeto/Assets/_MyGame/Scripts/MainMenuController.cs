using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load your game!

public class MainMenuController : MonoBehaviour
{
    [Header("Level Loading")]
    public string firstLevelName = "SafeRoom"; 

    public void StartGame()
    {
        // Loads the first level of your game
        SceneManager.LoadScene(firstLevelName);
    }

    public void QuitGame()
    {
        // This prints a message in the Unity Editor so you know it works
        Debug.Log("The player has quit the game!");
        
        // This actually closes the game when you build and play it for real
        Application.Quit();
    }
}