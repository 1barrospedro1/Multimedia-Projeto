using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        // 1. Unfreeze time (in case we came from a Game Over or Win screen)
        Time.timeScale = 1f;

        // 2. Unlock the cursor from the center of the screen
        Cursor.lockState = CursorLockMode.None;

        // 3. Make the cursor visible so we can click things!
        Cursor.visible = true;
    }

    // You can attach this to your 'Play' button!
    public void StartGame()
    {
        // Replace "Nightmare1" with the exact name of your first level
        SceneManager.LoadScene("Nightmare1");
    }

    // You can attach this to your 'Quit' button!
    public void QuitGame()
    {
        Debug.Log("Game is quitting!"); // This just prints in the editor so we know it works
        Application.Quit();
    }
}