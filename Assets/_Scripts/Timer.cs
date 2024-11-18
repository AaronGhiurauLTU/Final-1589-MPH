using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
	// default timer length in minutes
	public float startingTimeMinutes = 5f; 
	public TextMeshProUGUI timerTMP;

	// total time remaining, in seconds
	private float timeRemaining;

	// time remaining in minutes, seconds, and milliseconds
	private int timeMinutes, timeSeconds, timeMilliseconds;
	private bool timerRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        RestartTimer(startingTimeMinutes);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
	// reset the timer and start it
	public void RestartTimer(float startingTimeMinutes)
	{
		timeRemaining = startingTimeMinutes * 60;
		timerRunning = true;
	}

	// decrement the timer if it is running
	private void UpdateTimer()
	{
		if (!timerRunning)
			return;
		
		timeRemaining -= Time.deltaTime;

		// prevent the timer from going below 0
		timeRemaining = Math.Max(timeRemaining, 0);

		// update the minutes, seconds, and ms for a readable time
		ConvertTimeFromSeconds();

		// update timer UI
		timerTMP.text = GetTimeString();

		// stop the timer when it reaches 0
		if (timeRemaining <= 0)
		{
			timerRunning = false;

			// additional functionality when timer stops goes here
		}
	}

	// update the minutes, seconds, and milliseconds remaining
	private void ConvertTimeFromSeconds()
	{
		float remainder = timeRemaining;
		//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
		timeMinutes = Mathf.FloorToInt(remainder / 60);

		remainder -= timeMinutes * 60;

		timeSeconds = Mathf.FloorToInt(remainder);

		remainder -= timeSeconds;

		timeMilliseconds = Mathf.FloorToInt(remainder * 1000);
	}

	// returns a string of time formatted with (minutes):(seconds):(milliseconds)
	private string GetTimeString()
	{
		// pad with 0s to the left so there is no shifting string length
		return timeMinutes.ToString().PadLeft(2, '0') + ":" +
			timeSeconds.ToString().PadLeft(2, '0') + ":" +
			timeMilliseconds.ToString().PadLeft(3, '0');
	}


}
