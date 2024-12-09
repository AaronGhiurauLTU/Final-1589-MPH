using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public static Vector3 currentCheckpoint = Vector3.zero;
	public static Quaternion currentCheckpointRotation = Quaternion.identity;
    
	void Start()
	{
		// reset checkpoint on scene load
		currentCheckpoint = Vector3.zero;
		currentCheckpointRotation = Quaternion.identity;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (!other.transform.parent)
			return;
		// capsule collider is a child of the player object so that is why the parent's tag is checked
		if (other.transform.parent.CompareTag("Player"))
		{
			currentCheckpoint = transform.position;
			currentCheckpointRotation = transform.rotation;
		}
    }
}
