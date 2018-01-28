using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee : MonoBehaviour
{

    public float speed;
    public float speedH;
    public float speedV;
    public float distToGround;
    Rigidbody body;
    GameObject eyes;
    GameObject model;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        eyes = GetComponentInChildren<Camera>().gameObject;
        model = transform.Find("Abeja").gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInChildren<Animator>();
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
    }

    private void FixedUpdate()
    {
        var forward = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var altitude = Input.GetAxis("Mouse Y");

        body.velocity = ((transform.forward * speed * forward + (transform.right * speed * horizontal)) + (transform.up * speed * altitude)) * Time.deltaTime;
        animator.SetBool("Grounded", IsGrounded());
    }

    // Update is called once per frame
    void Update()
    {
        var yaw = speedH * Input.GetAxis("Mouse X");

        body.angularVelocity = new Vector3(0.0f, yaw, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.NameToLayer("Flower") == other.gameObject.layer)
        {
            other.GetComponent<Flower>().GotPollen();
        }
        if (LayerMask.NameToLayer("Enemy") == other.gameObject.layer)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
