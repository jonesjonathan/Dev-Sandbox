using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera camera;
    public float speed;
    public float sensitivity;
    public float jump;
    public float mouse_x;
    public float mouse_y;

    private bool isColliding;
    private Rigidbody rb;
    private Vector3 offset;

    private void Rotation()
    {
        mouse_y = Input.GetAxis("Mouse Y");
        mouse_x = Input.GetAxis("Mouse X");
        Vector2 rotate = new Vector2(mouse_y, mouse_x) * Time.deltaTime * sensitivity;
        transform.Rotate(0, rotate.y, 0);
        camera.transform.Rotate(0, rotate.y, 0);
    }
    //Should move forward and backward only
    private void Movement()
    {
        
        if(Input.GetKey(KeyCode.W))
        {
            rb.transform.Translate(transform.forward * speed, Space.World);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate((-transform.forward) * (speed / 2), Space.World);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.transform.Translate((-transform.right) * (speed / 2), Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Translate((transform.right) * (speed / 2), Space.World);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isColliding && rb.velocity.y <= 0)
            {
                //rb.AddForce(0.0f, jump, 0.0f, ForceMode.Impulse);
                rb.velocity = new Vector3(0, jump, 0);
                isColliding = false;
            }
        }
        camera.transform.position = transform.position + offset;
    }
    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
    private void Start()
    {
        isColliding = false;
        rb = GetComponent<Rigidbody>();
        offset = camera.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate () {
        Rotation();
        Movement();
	}
}
