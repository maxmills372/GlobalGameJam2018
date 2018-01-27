using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]

public class BasicZomz : MonoBehaviour 
{
	public UnityEngine.AI.NavMeshAgent agent { get; private set; } 
	public GameObject player_location;

	public int id;

	bool following = true;

	public float min_distance;

	public List<GameObject> nearby_zombz = new List<GameObject> ();

	Vector3 movement_offset = Vector3.zero;

	bool is_following = true;

	Vector3 move;

	Vector3 hive_centre = Vector3.zero;

	public float comfort_zone;


	// Use this for initialization
	void Start () 
	{
		GameObject temp = GameObject.Find ("Player");
		player_location = temp;

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.updatePosition = false;
		agent.updateRotation = false;


	}


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Zombz" && nearby_zombz.Contains(col.gameObject) != true)
		{

			nearby_zombz.Add (col.gameObject);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Zombz")
		{
			nearby_zombz.Remove (col.gameObject);
		}
	}

	float GetDistance()
	{
		return Vector3.Distance (transform.position, player_location.transform.position);
	}
		
	void UpdateHiveCentre(Vector3 vel)
	{
		hive_centre = vel;
	}

	bool IsGrounded()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, GetComponent<CapsuleCollider> ().height / 2)) 
		{
			if (hit.collider.tag == "Ground") 
			{
				return true;
			}
		}

		return false;
	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.P)) 
		{
			is_following = !is_following;
		}
			
		foreach (GameObject obj in nearby_zombz)
		{
			Vector3 force = obj.transform.position;
			//force.y = 0.0f;
			GetComponent<Rigidbody> ().AddExplosionForce (100.0f, force, comfort_zone);
		}
			
		transform.LookAt (player_location.transform);

		GetComponent<Rigidbody> ().AddExplosionForce (500.0f, player_location.transform.position, min_distance);


		if (is_following) 
		{			
			agent.SetDestination (player_location.transform.position);
			move = agent.desiredVelocity;

			//move 

			transform.position = transform.position + move * Time.deltaTime * (GetDistance()/10.0f);
		} 
		else
		{			
			agent.SetDestination (hive_centre);
			if (Vector3.Distance (transform.position, hive_centre) > 5.0f) 
			{
				move = agent.desiredVelocity;
				transform.position = transform.position + move * Time.deltaTime;
			}
		}

		if (IsGrounded() == false) 
		{
			transform.position = transform.position + new Vector3 (0.0f, -10.0f, 0.0f) * Time.deltaTime;
		}
			
		agent.nextPosition = transform.position;
	}
}
