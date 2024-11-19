using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (rotation * Vector3.forward) * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("KABOOM");
        if(!other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
