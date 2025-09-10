using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float timer = 10f;     // Total time for the countdown
    [SerializeField] TextMeshProUGUI timerText; //Refrence to the TextMeshProUGUI component to display the timer

    // Update is called once per frame
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
}
