using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour
{
    public void OnClick()
	{
		Time.timeScale = 1.0f;
		
		// load main menu scene
		SceneManager.LoadScene(0);
	}
}
