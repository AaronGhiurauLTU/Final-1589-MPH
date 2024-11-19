using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float maxForce = 750f;
	public float explosionRadius = 3f;
	void Start()
	{
		Debug.Log(Camera.main);
		if (!Camera.main)
			return;
			
		Vector3 direction = Camera.main.transform.parent.position - transform.position;
		Debug.Log(direction + " " + direction.magnitude);
		if (direction.magnitude <= explosionRadius)
		{
			FirstPersonController firstPersonController = Camera.main.transform.parent.GetComponent<FirstPersonController>();
			firstPersonController.AddExternalForce(direction * maxForce);
		}
	}
}
