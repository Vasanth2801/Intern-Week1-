using UnityEngine;

public class EventHandler : MonoBehaviour
{
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
        Debug.Log("Game Over! Time's up!");         //notifies when the game ends 
    }
}
