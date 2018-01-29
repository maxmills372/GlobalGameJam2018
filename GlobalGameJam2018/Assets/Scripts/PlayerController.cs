using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public GameObject camera_parent;

	public float camera_rotate_amount;

	float x_speed;
	float z_speed;

	public float movement_speed;

	public GameObject the_hive;

	//CharacterController character_controller;

	public Vector3 move_offset = Vector3.zero;

	public Animator anim;

	// Use this for initialization
	void Start () 
	{
		//character_controller = GetComponent<CharacterController> ();

		anim = GetComponent<Animator> ();

		the_hive = GameObject.Find("ZombHive");
	}


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Zombz") 
		{
				col.gameObject.SendMessage ("UpdatePlayer", this.gameObject);
				the_hive.GetComponent<HiveMind> ().AddZomb (col.gameObject);
		}
	}

	void MoveBack(Vector3 pos)
	{
		move_offset = new Vector3 (0.0f, 0.0f, -(60.0f - Vector3.Distance (pos, gameObject.transform.position))/10.0f);
		move_offset *= Time.deltaTime * 100.0f;
	}

	void CameraControl()
	{
		// Rotates the camera anti-clockwise
		if (Input.GetAxis ("CameraH") < -0.5f || Input.GetKey(KeyCode.Alpha2)) 
		{
			camera_parent.transform.Rotate (new Vector3 (0.0f, -camera_rotate_amount * Time.deltaTime, 0.0f));
		}
		// Rotates the camera clockwise
		else if (Input.GetAxis ("CameraH") > 0.5f|| Input.GetKey(KeyCode.Alpha3)) 
		{
			camera_parent.transform.Rotate (new Vector3 (0.0f, camera_rotate_amount * Time.deltaTime, 0.0f));
		}
	}

	public Transform GetCameraParentTransform()
	{
		return camera_parent.transform;
	}

	// Player movements, obviously
	void PlayerMovement()
	{
		x_speed = Input.GetAxis ("Horizontal") * movement_speed;
		z_speed = Input.GetAxis ("Vertical") * movement_speed;

		if (x_speed != 0.0f || z_speed != 0.0f) 
		{
			anim.SetBool ("Walking", true);

			Vector3 speed = (new Vector3 (x_speed, 0.0f, z_speed));

			speed = camera_parent.transform.rotation * speed;
			speed += move_offset;

			gameObject.transform.LookAt(gameObject.transform.position + new Vector3(speed.x, 0.0f, speed.z));

//		if (character_controller.isGrounded != true) 
//		{
//			speed.y = -10.0f;
//		}

			gameObject.transform.parent.position += (speed * Time.deltaTime);
		} 
		else 
		{
			anim.SetBool ("Walking", false);
		}
	}

	void Button_Input()
	{
		if (Input.GetButtonDown("Send_Red"))
		{
			print("Red was sent");
		}
		if (Input.GetButtonDown("Send_Blue"))
		{
			print("Blue was sent");
		}
		if (Input.GetButtonDown("Send_Yellow"))
		{
			print("Yellow was sent");
		}
		if (Input.GetButtonDown("Pulse"))
		{
			print("Pulse");
		}
		if (Input.GetButtonDown("Seperate"))
		{
			print("Z0MZ seperated");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		CameraControl ();
		PlayerMovement ();
		Button_Input ();
		if (move_offset != Vector3.zero) 
		{
			Vector3 nm = move_offset;
			nm.Normalize ();
			move_offset = move_offset - nm;
		}

	}

    //void OnCollisionEnter(Collision col)
    //{

    //    if (col.collider.tag == "Finish")
    //    {
    //        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0));
    //        Debug.Log("gjsfngk");
    //    }
    //}
}
