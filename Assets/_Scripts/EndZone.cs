using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndZone : MonoBehaviour
{
	public Canvas endScreen;
	public TextMeshProUGUI statsTMP;
	public GameObject gameManager;

	public GameObject particlesObj;

	void Start()
    {
	//	GetComponent<Renderer>().enabled = false;
        endScreen.enabled = false;
    }

	private void OnTriggerEnter(Collider other)
	{
		if (!other.transform.parent)
			return;
		// capsule collider is a child of the player object so that is why the parent's tag is checked
		if (other.transform.parent.CompareTag("Player"))
		{
			endScreen.enabled = true;
			Time.timeScale = 0f;
			Cursor.lockState = CursorLockMode.None;

			GameObject newParticles = Instantiate(particlesObj);
			newParticles.transform.position = other.transform.position;

			statsTMP.text = $"Finished in {gameManager.GetComponent<Timer>().GetTimeString()}!\n{DeathZone.deathCount} death(s)!";
		}
    }
}
