using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;                // Reference to the pause menu UI GameObject


    // Method to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);            // Hide the pause menu UI
        GameManager.instance.ResumeGame(); // Call the ResumeGame method from GameManager to resume the game
    }


    // Method to restart the game
    public void Restart()
    {
        GameManager.instance.Restart();              // Call the Restart method from GameManager to restart the game
    }
}