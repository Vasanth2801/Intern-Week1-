using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get;private set; }

    public AudioSource musicSource,clipSource;   // Reference to the AudioSource component for background music
    [SerializeField] private AudioClip musicClip;       // Reference to the AudioClip for background music
    [SerializeField] private AudioClip dash;          // Reference to the AudioSource component for dash sound effect

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
    public void PlayMusic()
    {
        if (musicSource != null && musicClip != null)
        {
            musicSource.clip = musicClip;   // Set the music clip to the AudioSource
            musicSource.Play();             // Start playing the music
        }
    }

    public void PlayDashSound()
    {
        clipSource.PlayOneShot(dash);   // Play the dash sound effect
    }
}