using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {

    public float speed;
    public float yaw;
    public float pitch;
    public float speedH;
    public float speedV;
    Rigidbody body;
    GameObject eyes;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        eyes = GetComponentInChildren<Camera>().gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        var forward = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var altitude = Input.GetAxis("Altitude");

        body.velocity = ((transform.forward * speed * forward + (transform.right * speed * horizontal)) + (transform.up * speed *altitude)) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * -Input.GetAxis("Mouse Y");
        body.angularVelocity=new Vector3(0.0f, yaw, 0.0f);
        eyes.transform.Rotate(new Vector3(pitch, 0.0f, 0.0f), Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        body.angularVelocity = Vector3.zero;
    }
    private void OnCollisionStay(Collision collision)
    {
        body.angularVelocity = Vector3.zero;
    }
}
