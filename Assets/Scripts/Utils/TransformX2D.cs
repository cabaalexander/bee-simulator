using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformX2D : MonoBehaviour {

    Rigidbody2D body;
    public float speed = 1.0f;
    public bool left;
    public bool right;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (left)
        {
            MoveLeft();
        } else if (right)
        {
            MoveRight();
        }
	}

    void MoveLeft()
    {
        body.MovePosition(body.position + Vector2.left * speed);
    }

    void MoveRight()
    {
        body.MovePosition(body.position - Vector2.left * speed);
    }
}
