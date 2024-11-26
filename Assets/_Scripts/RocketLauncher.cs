using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
	public GameObject rocket, rocketLaunchPosObj;
	public float reloadSpeed = 1;

	private float timeTillReload = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		timeTillReload -= Time.deltaTime;
		timeTillReload = Mathf.Max(timeTillReload, 0);
        if(Input.GetMouseButtonDown(0) && timeTillReload == 0) {
			// uses the position of the rocket launcher and the rotation of the camera
			timeTillReload = reloadSpeed;
            Instantiate(rocket, rocketLaunchPosObj.transform.position, transform.parent.rotation);
        } 
    }
}
