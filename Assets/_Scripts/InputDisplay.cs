using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputDisplay : MonoBehaviour
{
	public TextMeshProUGUI inputDisplay;

    void FixedUpdate()
    {
        // Build the display string for the input status
        
        string inputText = "";

        inputText += "\t" + (Input.GetKey(KeyCode.W) ? "W" : " ") + "\n";
        inputText += (Input.GetKey(KeyCode.A) ? "A" : " ") + "\t";
        inputText += (Input.GetKey(KeyCode.S) ? "S" : " ") + "\t";
        inputText += (Input.GetKey(KeyCode.D) ? "D" : " ") + "\n";

        inputText += (Input.GetMouseButton(0) ? "M1" : " ") + "\t";
        inputText += (Input.GetKey(KeyCode.LeftControl) ? "Ctrl" : " ") + "\n\t";
        inputText += (Input.GetKey(KeyCode.Space) ? "SPACE" : " ") + " ";
        inputDisplay.text = inputText;
    }
}
