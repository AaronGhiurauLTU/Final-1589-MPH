using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float accel = 200f;
    public float airAccel = 200f;
    public float maxSpeed = 6.4f;
    public float maxAirSpeed = 0.6f;

    public float jumpForce = 5f;
    private float lastJumpPress = -1f;
    private float jumpPressDuration = 0.1f;
    private bool onGround = false;

    public float yawSpeed   =   260.0f;
    public float pitchSpeed =   260.0f;
    public float minPitch   =   -45.0f;
    public float maxPitch   =   45.0f;

    public Transform groundReference;

	public Vector3 rocketVelocity = Vector3.zero;
    private Rigidbody rb;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = GetComponentInChildren<Camera>().transform; 

		// lock the cursor
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            lastJumpPress = Time.time;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //put all input axis info into variable
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float yaw = Input.GetAxis("Mouse X");
        float pitch = Input.GetAxis("Mouse Y");

        //apply rotation
        transform.localEulerAngles += new Vector3(
            0,
            yaw * yawSpeed * Time.deltaTime,
            0);

        float pitchDelta = -1 * pitch * pitchSpeed * Time.deltaTime;
        float newPitch = cameraTransform.localEulerAngles.x + pitchDelta;
        newPitch = angleWithin180(newPitch);

        newPitch = Mathf.Clamp(newPitch, minPitch, maxPitch);

        cameraTransform.localEulerAngles = new Vector3(newPitch,
            cameraTransform.localEulerAngles.y,
            cameraTransform.localEulerAngles.z);

        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftControl)) {
            rb.mass = 0.75f;
        } else {
            rb.mass = 1f;
        }

        Vector3 playerVelocity = GetComponent<Rigidbody>().velocity;
        playerVelocity += CalulateMovement(h, v, playerVelocity);
        GetComponent<Rigidbody>().velocity = playerVelocity;
    }

	public void AddExternalForce(Vector3 force)
	{
		rb.AddForce(force);
	}

	public void UpdateMouseSensitivity(int newSensitivity)
	{
		yawSpeed = newSensitivity;
		pitchSpeed = newSensitivity;
	}

    private bool IsGrounded()
    {
        return Physics.Raycast(groundReference.position, Vector3.down, .15f);
    }

    private float angleWithin180(float angle)
    {
        return angle > 180 ? angle - 360 : angle;
    }

    private Vector3 CalulateMovement(float horizontal, float vertical, Vector3 playerVelocity)
    {
        onGround = IsGrounded();

        float curAccel = accel;
        float curMaxSpeed = maxSpeed;
        if(!onGround)
        {
            curAccel = airAccel;
            curMaxSpeed = maxAirSpeed;
        }

        Vector3 camRotation = new Vector3(0f, cameraTransform.rotation.eulerAngles.y, 0f);
        Vector3 inputVelocity = Quaternion.Euler(camRotation) * new Vector3(horizontal * curAccel, 0f, vertical * curAccel);
        

        Vector3 alignedInputVelocity = new Vector3(inputVelocity.x, 0f, inputVelocity.z) * Time.deltaTime;
        Vector3 currentVelocity = new Vector3(playerVelocity.x, 0f, playerVelocity.z);

        float max = Mathf.Max(0f, 1 - (currentVelocity.magnitude / curMaxSpeed));
        float velocityDot = Vector3.Dot(currentVelocity, alignedInputVelocity);

        Vector3 modifiedVelocity = alignedInputVelocity * max;
        
        Vector3 correctVelocity = Vector3.Lerp(alignedInputVelocity, modifiedVelocity, velocityDot);

        correctVelocity += GetJumpVelocity(playerVelocity.y);
        return correctVelocity;
    }

    private Vector3 GetJumpVelocity(float y)
    {
        Vector3 jumpVelocity = Vector3.zero;
        if(Time.time < lastJumpPress + jumpPressDuration && y < jumpForce && IsGrounded())
        {
            lastJumpPress = -1f;
            jumpVelocity = new Vector3(0f, jumpForce - y, 0f);
        }
        return jumpVelocity;
    }
}
