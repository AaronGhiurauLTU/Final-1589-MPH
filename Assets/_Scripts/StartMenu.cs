using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Behaviour button;
	void Start()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextScene < 0 && nextScene >= SceneManager.sceneCountInBuildSettings) {
            button.enabled = false;
        }
    }
	public void StartGame()
	{
		Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
