using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public bool isColliding;

	private Rigidbody rb;
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
                rb.AddForce(0.0f, 7.5f, 0.0f, ForceMode.Impulse);
                //isColliding = false;
            }
        }
	}
	private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }

	private void OnCollisionExit(Collision collision)
	{
		isColliding = false;
	}
	// Use this for initialization
	void Start () {
		isColliding = false;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Movement();
		Debug.Log(isColliding);
	}
}
