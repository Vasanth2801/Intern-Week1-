using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;                // Reference to the pause menu UI GameObject


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause();         // Call the pause method when the Escape key is pressed
        }
    }

    // Method to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);            // Hide the pause menu UI
        GameManager.instance.ResumeGame(); // Call the ResumeGame method from GameManager to resume the game
        AudioManager.Instance.PlayMusic(); // Resume background music
    }

    //Method to pause the game
    public void pause()
    {
        pauseMenuUI.SetActive(true);             // Show the pause menu UI
        Time.timeScale = 0f;                     // Pause the game by setting time scale to 0
        AudioManager.Instance.clipSource.Pause(); // Pause background music
        AudioManager.Instance.musicSource.Pause(); // Pause background music
    }


    // Method to restart the game
    public void Restart()
    {
        GameManager.instance.Restart();              // Call the Restart method from GameManager to restart the game
    }
}