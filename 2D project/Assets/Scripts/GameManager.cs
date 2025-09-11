using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }      //Singleton instance of GameManager

    //Calls the method before Start()
    void Awake()
    {
        //Singleton pattern implementation
        if (instance != null && instance != this)       // If an instance already exists and it's not this one
        {
            Destroy(gameObject);                      //Destroy this instance
            return;
        }
        else
        {
            instance = this;                             // Set this as the instance
            DontDestroyOnLoad(gameObject);               //To prevent the GameManager from being destroyed on scene load
            Time.timeScale = 1f;                        // Ensure game time is running
        }
    }


    // Method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f;        // Resume game time
    }

    // Method to restart the game
    public void Restart()
    {
        SceneManager.LoadScene("SingletonPatterns");         //Load the Scene named "SingletonPatterns"
        Time.timeScale = 1f;                                // Ensure game time is running
        AudioManager.Instance.PlayMusic();                     // Resume background music
    }

    
}
