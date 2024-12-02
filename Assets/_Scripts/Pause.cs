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
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;

			pauseCanvas.enabled = paused;

			if (!paused)
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
			else
			{
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
