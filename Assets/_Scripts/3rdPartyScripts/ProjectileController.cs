﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRookGames.Weapons
{
    public class ProjectileController : MonoBehaviour
    {
        // --- Config ---
        public float speed = 100;

		public GameObject explosionObj;
        public LayerMask collisionLayerMask;

        // --- Explosion VFX ---
        public GameObject rocketExplosion;

        // --- Projectile Mesh ---
        public MeshRenderer projectileMesh;

        // --- Script Variables ---
        private bool targetHit;

        // --- Audio ---
        public AudioSource inFlightAudioSource;

        // --- VFX ---
        public ParticleSystem disableOnHit;


        private void Update()
        {
            // --- Check to see if the target has been hit. We don't want to update the position if the target was hit ---
            if (targetHit) return;

            // --- moves the game object in the forward direction at the defined speed ---
            transform.position += transform.forward * (speed * Time.deltaTime);
        }


        /// <summary>
        /// Explodes on contact.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            // --- return if not enabled because OnCollision is still called if compoenent is disabled ---
            if (!enabled) return;

			if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Checkpoint")) {
				GameObject explosion = Instantiate(explosionObj);
				explosion.transform.position = transform.position;
				Destroy(gameObject);

				// --- Explode when hitting an object and disable the projectile mesh ---
				Explode();
				projectileMesh.enabled = false;
				targetHit = true;
				inFlightAudioSource.Stop();
				foreach(Collider col in GetComponents<Collider>())
				{
					col.enabled = false;
				}
				disableOnHit.Stop();


				// --- Destroy this object after 2 seconds. Using a delay because the particle system needs to finish ---
				Destroy(gameObject, 5f);

				// // Destroy destructible objects
				// if (other.gameObject.CompareTag("Destructible")) {
				// 	Destroy(other.gameObject);
				// }
			}
        }


        /// <summary>
        /// Instantiates an explode object.
        /// </summary>
        private void Explode()
        {
            // --- Instantiate new explosion option. I would recommend using an object pool ---
            GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation, null);
        }
    }
}