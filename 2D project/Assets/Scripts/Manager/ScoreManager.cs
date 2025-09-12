using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }   // Singleton instance
    public int score;                      // Player's score
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the UI text component

    void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
        }
    }

    void Start()
    {
        score = 0;                          // Initialize score
        UpdateScoreText();                  // Update the score display
    }


    public void AddScore(int points)       // Method to add points to the score
    {
        score += points;                    // Increase score
        UpdateScoreText();                  // Update the score display
    }

    void UpdateScoreText()                 // Method to update the score display
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the UI text
        }
    }
}
