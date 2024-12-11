using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunParticlesWhilePaused : MonoBehaviour
{
     private ParticleSystem pSystem;

	public void Awake()
	{
		pSystem = gameObject.GetComponent<ParticleSystem>();
		Destroy(gameObject, 5);
	}

	public void Update()
	{
		pSystem.Simulate(Time.unscaledDeltaTime,true,false);
	}
}
