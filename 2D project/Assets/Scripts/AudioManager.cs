using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get;private set; }

    [SerializeField] private AudioSource musicSource;   // Reference to the AudioSource component for background music
    [SerializeField] private AudioClip musicClip;       // Reference to the AudioClip for background music

    //Awake calls before Start
    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);                      // Destroy this instance if another instance already exists
            return;                                  // Exit the method
        }
        else
        {
            Instance = this;                          // Set this as the instance
            DontDestroyOnLoad(gameObject);            // Prevent the AudioManager from being destroyed on scene load
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        PlayMusic();   // Start playing the background music
    }

    // Method to play background music
    void PlayMusic()
    {
        if (musicSource != null && musicClip != null)
        {
            musicSource.clip = musicClip;   // Set the music clip to the AudioSource
            musicSource.Play();             // Start playing the music
        }
    }
}