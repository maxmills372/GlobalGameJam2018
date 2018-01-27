﻿using System.Collections;
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
	bool is_collected = false;

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

	// Adds the nearby zomb to the nearby list
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Zombz" && nearby_zombz.Contains(col.gameObject) != true)
		{

			nearby_zombz.Add (col.gameObject);
		}
	}

	// removes a zomb from the nearby list, they are too far away
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Zombz")
		{
			nearby_zombz.Remove (col.gameObject);
		}
	}
		
	// Updates the average position of the hive, i.e. the centre of the hive
	void UpdateHiveCentre(Vector3 vel)
	{
		hive_centre = vel;
	}

	// return true if the zomb is on the ground
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

	// toggles if the zomb is following the player
	void ToggleFollow(bool TF)
	{
		is_following = TF;
	}

	// updates what the zomb considers the player
	void UpdatePlayer(GameObject player)
	{
		player_location = player;
		is_collected = true;
	}

	// pushes away nearby zombz, and gets pushed by the player
	void CrowdControl()
	{
		foreach (GameObject obj in nearby_zombz)
		{
			Vector3 force = obj.transform.position;

			// EXPLOSIONS!!!!!!!!!!!!!!
			GetComponent<Rigidbody> ().AddExplosionForce (100.0f, force, comfort_zone);
		}

		GetComponent<Rigidbody> ().AddExplosionForce (500.0f, player_location.transform.position, min_distance);
	}

	// Update is called once per frame
	void Update () 
	{
		CrowdControl ();

		//Debug.Log (hive_centre);

		if (is_collected)
		{
			if (is_following)
			{			
				// Pathfinds to the player, speeds up the further away it is
				agent.SetDestination (player_location.transform.position);
				move = agent.desiredVelocity;

				transform.position = transform.position + move * Time.deltaTime * (Vector3.Distance(transform.position, player_location.transform.position) / 10.0f);

				transform.LookAt (player_location.transform);
			} 
			else 
			{			
				// pathfind to the centre of the hive, until its 5 units from it (stops them spazzing out in the centre)
				agent.SetDestination (hive_centre);
				if (Vector3.Distance (transform.position, hive_centre) > 5.0f) 
				{
					move = agent.desiredVelocity;
					transform.position = transform.position + move * Time.deltaTime * Vector3.Distance (transform.position, hive_centre) / 10.0f;
				}
				transform.LookAt (hive_centre);
			}

			if (IsGrounded () == false) 
			{
				transform.position = transform.position + new Vector3 (0.0f, -10.0f, 0.0f) * Time.deltaTime;
			}
		}

		agent.nextPosition = transform.position;
	}
}
