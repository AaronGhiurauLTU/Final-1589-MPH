using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
	public GameObject explosionObj;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;

		// ensure rockets get destroyed after 10 seconds so they do not waste resources
		Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (rotation * Vector3.forward) * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("KABOOM");
        if(!other.CompareTag("Player")) {
			GameObject explosion = Instantiate(explosionObj);
			explosion.transform.position = transform.position;
            Destroy(gameObject);

			// Destroy destructible objects
			if (other.CompareTag("Destructible")) {
				Destroy(other.gameObject);
			}
        }
    }
}
