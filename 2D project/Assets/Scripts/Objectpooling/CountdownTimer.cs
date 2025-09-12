using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] float timer = 10f;     // Total time for the countdown
    [SerializeField] TextMeshProUGUI timerText; //Refrence to the TextMeshProUGUI component to display the timer
    [SerializeField] float timeToDecrease = 1f; // Time interval to decrease the timer
    [SerializeField] Slider sliderArea;         // Reference to the UI Slider component

    // Creating the Delegate and event for game over
    public delegate void HandleGameEnd();         //Delegate for game over event 
    public static event HandleGameEnd OnGameEnd;   //Event triggered when the game ends 

     //Start the first frame of the Game
    private void Start()
    {
        sliderArea.maxValue = timer;                                 // Update the slider value to reflect the current timer
        StartCoroutine(StartTimer());   // Start the timer countdown coroutine
    }

    //A method for Timer Countdown using Coroutine
    IEnumerator StartTimer()   // Coroutine to handle the countdown
    {
        float remainingTime = timer; // Store the initial timer value
        while (timer > 0)      // Continue until the timer reaches zero
        {
           sliderArea.value = timer;                                 // Update the slider value to reflect the current timer
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString(); // Display the timer rounded up to the nearest whole number
            yield return new WaitForSeconds(timeToDecrease);         // Wait for 1 second
            timer--;                                                 // Decrease the timer by 1
        }

        sliderArea.value = 0;                                       // Update the slider value to zero
        timerText.text = "Time: 0";      // Ensure the timer text shows zero when time is up
        OnGameEnd?.Invoke();             //Trigger the onGameEnd event if there are subscribers
    }



    // Timer Countdown using Update method 
    /*
    void Update()
    {
        timerText.text = timer.ToString();      // Update the displayed timer text

        if (timer >0)                          // Decrease the timer if it's above zero
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString(); // Display the timer rounded up to the nearest whole number
            timer -= Time.deltaTime;         // Decrease the timer by the time elapsed since the last frame
        }
        else
        {
            timerText.text = "Time: 0";      // Ensure the timer text shows zero when time is up
        }
    }
    */

}
