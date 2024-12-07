using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
	public GameObject playerPrefab;
	public static int deathCount = 0;

	void Start()
	{
		// reset death count on scene load
		deathCount = 0;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (!other.transform.parent)
			return;
		// capsule collider is a child of the player object so that is why the parent's tag is checked
		if (other.transform.parent.CompareTag("Player"))
		{
			// destroy the old player
			Destroy(other.transform.parent.gameObject);

			// respawn a new character
			GameObject newPlayer = Instantiate(playerPrefab);

			newPlayer.transform.position = Checkpoint.currentCheckpoint;

			deathCount++;
		}
    }
}
