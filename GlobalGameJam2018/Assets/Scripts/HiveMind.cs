﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMind : MonoBehaviour 
{

	public List<GameObject> the_hive = new List<GameObject>();

	public GameObject start;

	public GameObject player;

	public GameObject hive_actual;

	// The different colours
	public enum Zom_Colour
	{
		GREY,
		RED,
		BLUE,
		YELLOW
	}

	//int hive_count = 0;
	public int[] counter;
	public int[] maximum;

	public int start_count;

	public GameObject zomb;

	public float comfort_zone = 1.0f;

	Vector3 hive_centre = Vector3.zero;

	bool is_following = true;

	// Use this for initialization
	void Start () 
	{
		int j = 0;

		// spawns some zombz 
		for (int i = 0; i < start_count; i++) 
		{
			Vector3 pos = start.transform.position;
			if (i < 50) {
				pos.x += i * 3.0f;
			} 
			else 
			{
				pos.x += i * 2.0f - 50.0f;
				j = 5;
			}
			pos.z += j;
			GameObject temp_zomb = Instantiate (zomb, pos, Quaternion.identity, transform);
			BasicZombz temp_sript = temp_zomb.GetComponent<BasicZombz> ();

			temp_sript.id = i;

			temp_sript.comfort_zone = comfort_zone;


		}

		// Initialise counters
		counter = new int[4] {0,0,0,0};
		maximum = new int[4] {100,0,0,0};

		player = GameObject.Find("Player");
	}

	// adds a zomb to the hive, parents it to the correct gameobject, and tells it if the hive is currently following the player
	public void AddZomb(GameObject zomb)
	{
		if (the_hive.Contains (zomb) != true) 
		{
			the_hive.Add (zomb);
			Hive_Count();
			zomb.transform.SetParent (hive_actual.transform);
			zomb.SendMessage ("ToggleFollow", is_following);
		}

		// Recalculate the maximum of the Z0MZ
		Calculate_Maximum();
	}

	public void RemoveZomb(GameObject zomb)
	{
		if (the_hive.Contains (zomb) == true) 
		{
			zomb.SendMessage ("Release");
			the_hive.Remove (zomb);
			Hive_Count();
		}

		// Recalculate the maximum of the Z0MZ
		Calculate_Maximum();
	}

	// Make all zomz follow
	public void All_Follow()
	{
		is_following = true;
		foreach (GameObject obj in the_hive) 
		{
			obj.SendMessage ("ToggleFollow", is_following);
		}
	}

	// calculates the average poaition of the hive, i.e the centre, and then updates each zomb with said position
	void UpdateHiveCentre()
	{		
		if (the_hive.Count > 0)
		{
			hive_centre = Vector3.zero;

			foreach (GameObject obj in the_hive) 
			{
				hive_centre += obj.transform.position;//localPosition;
			}

			hive_centre.x /= the_hive.Count;//(counter[0] + counter[1] + counter[2] + counter[3]);
			hive_centre.y /= the_hive.Count;//(counter[0] + counter[1] + counter[2] + counter[3]);
			hive_centre.z /= the_hive.Count;//(counter[0] + counter[1] + counter[2] + counter[3]);

			foreach (GameObject obj in the_hive) 
			{
				obj.SendMessage ("UpdateHiveCentre", hive_centre);
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		// if the user presses P tells the zombz in the hive to toggle their following state
		if (Input.GetButtonDown ("Seperate")) 
		{
			is_following = !is_following;
			foreach (GameObject obj in the_hive) 
			{
				obj.SendMessage ("ToggleFollow", is_following);
			}	
		}
			
		UpdateHiveCentre ();

		// if the zombz are not following move them independantly of the player
		if (!is_following) 
		{
			float x_speed = Input.GetAxis ("ZombzHorz") * 10.0f;
			float z_speed = Input.GetAxis ("ZombzVert") * 10.0f;

			Vector3 move = Vector3.zero;

			move.x += x_speed * Time.deltaTime;
			move.z += z_speed * Time.deltaTime;

			move = player.GetComponent<PlayerController> ().GetCameraParentTransform ().rotation * move;

			hive_actual.transform.position += move;
		}
	}

	// Count all the colours of the Z0MZ
	void Hive_Count ()
	{
		// Reset the counter
		counter = new int[4]{0,0,0,0};

		if (the_hive.Count > 0)
		{
			foreach (GameObject obj in the_hive) 
			{
				counter[(int)obj.GetComponent<BasicZombz>().zom_colour]++;
			}
		}
	}

	// Change colour of a Z0M
	public bool Change_Colour (GameObject target_zom, int new_colour)
	{
		//Check if there can be more of this colour
		if (counter[(int)new_colour] < maximum[(int)new_colour])
		{
			// Check for this Z0M in the hive mind
			if (the_hive.Contains (target_zom))
			{
				// Find the renderer
				Renderer this_renderer = target_zom.GetComponent<Renderer>();

				// Create colour variable
				Color color;

				// Change colour to object colour
				switch (new_colour)
				{
				case (int)Zom_Colour.RED:
					color = Color.red;
					break;
				case (int)Zom_Colour.BLUE:
					color = Color.blue;
					break;
				case (int)Zom_Colour.YELLOW:
					color = Color.yellow;
					break;
				default:
					color = Color.black;
					break;
				}
				this_renderer.material.color = color;
				target_zom.GetComponent<Light> ().color = color;

				// Remove a grey and add one of the new colour
				counter[(int)Zom_Colour.GREY]--;
				counter[(int)new_colour]++;

				// Change has occurred
				return true;
			}
			else
			{
				//No change
				return false;
			}
		}
		else
		{
			//No change
			return false;
		}
	}

	void Calculate_Maximum()
	{
		// Calculate total Z0MZ
		int total = counter[(int)Zom_Colour.GREY] + counter[(int)Zom_Colour.RED] + counter[(int)Zom_Colour.BLUE] + counter[(int)Zom_Colour.YELLOW];
		
		//Find individual maximums
		maximum[(int)Zom_Colour.RED] = total / 3;
		maximum[(int)Zom_Colour.BLUE] = maximum[(int)Zom_Colour.RED];
		maximum[(int)Zom_Colour.YELLOW] = total - maximum[(int)Zom_Colour.BLUE] - maximum[(int)Zom_Colour.RED];
	}
}
