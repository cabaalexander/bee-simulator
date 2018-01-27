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
    }

    private void FixedUpdate()
    {
        var forward = Input.GetAxis("Vertical");
        var vertical = Input.GetAxis("Horizontal");

        body.velocity = ((Vector3.forward * forward) + (Vector3.right * vertical)) * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * -Input.GetAxis("Mouse Y");
        body.angularVelocity=new Vector3(0.0f, yaw, 0.0f);
        eyes.transform.Rotate(new Vector3(pitch, 0.0f, 0.0f), Space.Self);
    }
}
