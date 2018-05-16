using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float sensitivity;
    public float jump;
    public bool isColliding;
    private Rigidbody rb;

    private void Rotation()
    {
        Vector3 rotate = new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * sensitivity;
        transform.Rotate(rotate);
    }
    //Should move forward and backward only
    private void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * speed, Space.World);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate((-transform.forward) * (speed / 2), Space.World);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate((-transform.right) * (speed / 2), Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((transform.right) * (speed / 2), Space.World);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isColliding && rb.velocity.y == 0)
            {
                rb.AddForce(0.0f, jump, 0.0f, ForceMode.Impulse);
                isColliding = false;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }
    private void Start()
    {
        isColliding = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        Rotation();
        Movement();
	}
}
