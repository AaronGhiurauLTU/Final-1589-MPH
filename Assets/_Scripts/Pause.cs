using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	public Canvas pauseCanvas;
	public Scrollbar sensitivityScrollbar;
	public TextMeshProUGUI sensitivityValueLabel;
	private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		// toggle pause if escape is pressed, and you cannot pause if time is already frozen (such as from winning)
        if (Input.GetKeyDown(KeyCode.Escape) && !(!paused && Time.timeScale == 0))
		{
			paused = !paused;

			pauseCanvas.enabled = paused;
			sensitivityScrollbar.value = FirstPersonController.yawSpeed / 1000;
			if (!paused)
			{
				Time.timeScale = 1f;
				Cursor.lockState = CursorLockMode.Locked;
			}
			else
			{
				Time.timeScale = 0f;
				Cursor.lockState = CursorLockMode.None;
			}
		}
    }

	public void SensitivityBarChanged()
	{
		int newSensitivity = (int)(sensitivityScrollbar.value * 1000);
		sensitivityValueLabel.text = newSensitivity + "";
		if (!Camera.main)
			return;

		FirstPersonController fpc = Camera.main.transform.parent.GetComponent<FirstPersonController>();
	
		fpc.UpdateMouseSensitivity(newSensitivity);
	}
}
