using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]

public class BasicZombz : MonoBehaviour 
{
	public enum Zom_Colour
	{
		GREY,
		RED,
		BLUE,
		YELLOW
	}

	Material mat;
	public GameObject body;


	public Animator anim;

	// The colour that the zom is
	public Zom_Colour zom_colour;	
	Color color;

	public UnityEngine.AI.NavMeshAgent agent { get; private set; } 
	public GameObject player_location;

	public int id;

	public GameObject hive_mind;	// The hive mind all the Z0MZ are a part of

	public float min_distance;

	public List<GameObject> nearby_zombz = new List<GameObject> ();

	bool is_following = true;
	bool is_collected = false;

	Vector3 move;

	Vector3 hive_centre = Vector3.zero;

	public float comfort_zone;

	public bool activated = false;

	// Use this for initialization
	void Start () 
	{
		player_location = gameObject;
		//this_renderer = GetComponent<Renderer> ();

		GameObject temp = GameObject.Find ("Player");
		player_location = temp;

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.updatePosition = false;
		agent.updateRotation = false;

		min_distance = agent.stoppingDistance - 0.5f;

		// Find the renderer
		//Renderer this_renderer = gameObject.GetComponent<Renderer>();

		// Change colour to object colour
		switch (zom_colour)
		{
		case Zom_Colour.GREY:
			color = Color.grey;
			break;
		case Zom_Colour.RED:
			color = Color.red;
			break;
		case Zom_Colour.BLUE:
			color = Color.blue;
			break;
		case Zom_Colour.YELLOW:
			color = Color.yellow;
			break;
		default:
			color = Color.black;
			break;
		}

		mat = body.GetComponent<Renderer> ().materials [2];
		mat.color = color;
		mat.SetColor("_EmmisionColor", color);
		GetComponentInChildren<Light> ().color = color;

		hive_mind = GameObject.Find("ZombHive");
		anim = GetComponent<Animator>();
	}

	public void ChangeColor(Color color)
	{
		body.GetComponent<Renderer> ().materials [2].color = color;
	}

	// Adds the nearby zomb to the nearby list
	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Zombz" && nearby_zombz.Contains(col.gameObject) != true)
		{
			nearby_zombz.Add (col.gameObject);

			// Check if this zom is grey
			if (zom_colour == Zom_Colour.GREY)
			{ 
				// Check if other zom is not grey
				if(col.gameObject.GetComponent<BasicZombz>().zom_colour != Zom_Colour.GREY)
				{
					// Update the hive
					if(hive_mind.GetComponent<HiveMind>().Change_Colour(gameObject, (int)col.gameObject.GetComponent<BasicZombz>().zom_colour))
					{
						//Set colour to the colour of the other zom
						zom_colour = col.gameObject.GetComponent<BasicZombz>().zom_colour;
					}
				}
			}
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
		
	public void DeathHasOccured()
	{
		Release (true);
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
		if (activated == false) 
		{
			player_location = player;
			is_collected = true;

			Debug.Log ("new player");
		}
	}

	public void SetTarget(GameObject target)
	{
		player_location = target;
		activated = true;
		Debug.Log (target.name);
	}

	void Release(bool dead)
	{
		is_collected = false;
		hive_mind.GetComponent<HiveMind> ().RemoveZomb (gameObject, dead);
	}

	// pushes away nearby zombz, and gets pushed by the player
	void CrowdControl()
	{
		if (activated == false) 
		{
			foreach (GameObject obj in nearby_zombz) 
			{
				if(obj != null)
				{
					Vector3 force = obj.transform.position;

					// EXPLOSIONS!!!!!!!!!!!!!!
					GetComponent<Rigidbody> ().AddExplosionForce (100.0f, force, comfort_zone);
				}
			}

			GetComponent<Rigidbody> ().AddExplosionForce (500.0f, player_location.transform.position, min_distance);
		}
	}

	// Update is called once per frame
	void Update () 
	{

		anim.SetFloat("Distance", Vector3.Distance(transform.position, player_location.transform.position));



		//anim.Play ("Run");
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

				transform.LookAt (player_location.transform.position);// GameObject.Find ("Player").transform);

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

				//Debug.Log (hive_centre);
			}

			if (IsGrounded () == false) 
			{
				transform.position = transform.position + new Vector3 (0.0f, -10.0f, 0.0f) * Time.deltaTime;
			}
		}

		agent.nextPosition = transform.position;


	}
}
