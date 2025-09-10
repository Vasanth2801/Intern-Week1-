using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    
    [SerializeField] float timer = 10f;     // Total time for the countdown
    [SerializeField] TextMeshProUGUI timerText; //Refrence to the TextMeshProUGUI component to display the timer
    [SerializeField] float timeToDecrease = 1f; // Time interval to decrease the timer

    //Start the first frame of the Game
    private void Start()
    {
        StartCoroutine(StartTimer());   // Start the timer countdown coroutine
    }

    //A method for Timer Countdown using Coroutine
    IEnumerator StartTimer()   // Coroutine to handle the countdown
    {
        while(timer > 0)      // Continue until the timer reaches zero
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString(); // Display the timer rounded up to the nearest whole number
            yield return new WaitForSeconds(timeToDecrease);         // Wait for 1 second
            timer--;                                                 // Decrease the timer by 1
        }

        timerText.text = "Time: 0";      // Ensure the timer text shows zero when time is up
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
