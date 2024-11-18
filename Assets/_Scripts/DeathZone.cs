using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
	public GameObject playerPrefab;
	private void OnTriggerEnter(Collider other)
	{
		// capsule collider is a child of the player object so that is why the parent's tag is checked
		if (other.transform.parent.CompareTag("Player"))
		{
			// destroy the old player
			Destroy(other.transform.parent.gameObject);

			// respawn a new character
			Instantiate(playerPrefab);
		}
    }
}
