using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel; // Reference to the Game Over panel
    [SerializeField] GameObject gameOnPanel;  // Reference to the Game On panel
    private void OnEnable()
    {
        CountdownTimer.OnGameEnd += HandleGameEnd; // Subscribe to the OnGameEnd event
    }

    private void OnDisable()
    {
        CountdownTimer.OnGameEnd -= HandleGameEnd;   //Unsubscribe from the OnGameEnd event 
    }

    public void HandleGameEnd()
    {
        gameOnPanel.SetActive(false);   // Deactivate the Game On panel
        gameOverPanel.SetActive(true); // Activate the Game Over panel
        Debug.Log("Game Over! Time's up!");         //notifies when the game ends 
    }
}
