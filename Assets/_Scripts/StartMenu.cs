using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject button;
	void Start()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextScene >= SceneManager.sceneCountInBuildSettings) {
            button.SetActive(false);
        }
    }
	public void StartGame()
	{
		Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
