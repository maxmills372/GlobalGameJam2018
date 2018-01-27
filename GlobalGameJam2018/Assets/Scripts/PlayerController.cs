﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public GameObject camera_parent;

	public float camera_rotate_amount;

	float x_speed;
	float z_speed;

	public float movement_speed;

	CharacterController character_controller;

	List<BasicZomz> basic_zombz = new List<BasicZomz>();

	// Use this for initialization
	void Start () 
	{
		character_controller = GetComponent<CharacterController> ();
	}



	void CameraControl()
	{
		if (Input.GetKey (KeyCode.Alpha2)) 
		{
			camera_parent.transform.Rotate (new Vector3 (0.0f, camera_rotate_amount * Time.deltaTime, 0.0f));
		}
		else if (Input.GetKey (KeyCode.Alpha3)) 
		{

			camera_parent.transform.Rotate (new Vector3 (0.0f, -camera_rotate_amount * Time.deltaTime, 0.0f));
		}
	}

	void PlayerMovement()
	{
		x_speed = Input.GetAxis ("PlayerHorz") * movement_speed;
		z_speed = Input.GetAxis ("PlayerVert") * movement_speed;

		Vector3 speed = new Vector3 (x_speed, 0.0f, z_speed);

		speed = camera_parent.transform.rotation * speed;

		if (character_controller.isGrounded != true) 
		{
			speed.y = -10.0f;
		}

		character_controller.Move (speed * Time.deltaTime);
	}

	// Update is called once per frame
	void Update ()
	{
		CameraControl ();
		PlayerMovement ();

	}
}
