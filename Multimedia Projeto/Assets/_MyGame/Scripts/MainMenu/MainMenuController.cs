using UnityEngine;
using UnityEngine.SceneManagement; // To load the game

public class MainMenuController : MonoBehaviour
{
    [Header("Level Loading")]
    public string firstLevelName = "SafeRoom"; 

    public void StartGame()
    {
        // Loads the first level of the game
        SceneManager.LoadScene(firstLevelName);
    }

    public void QuitGame()
    {
        // This prints a message in the Unity Editor for testing
        Debug.Log("The player has quit the game!");
        
        // This actually closes the game when building and playing it for real
        Application.Quit();
    }
}