﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	
	public Transform player;
	public float sensitivity;

	private void Rotation()
	{
		float mouse_y = Input.GetAxis("Mouse Y");
		float mouse_x = Input.GetAxis("Mouse X");
		Vector3 x_rotation = Vector3.right * Time.deltaTime * -mouse_y * sensitivity;
		Vector3 y_rotation = Vector3.up * Time.deltaTime * mouse_x * sensitivity;

		transform.Rotate(x_rotation, Space.Self); //Looks up and down relative to the direction that we're facing
		transform.Rotate(y_rotation, Space.World); //Looks left and right relative to the world Y axis 
		player.Rotate(y_rotation, Space.World);
	}
	private void LateUpdate () {
		Rotation();
		transform.position = player.position;
	}
}
