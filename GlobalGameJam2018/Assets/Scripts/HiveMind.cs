using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMind : MonoBehaviour 
{

	public List<GameObject> the_hive = new List<GameObject>();

	public GameObject start;

	public GameObject player;

	public GameObject hive_actual;

	int hive_count = 0;
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
			BasicZomz temp_sript = temp_zomb.GetComponent<BasicZomz> ();

			temp_sript.id = i;

			temp_sript.comfort_zone = comfort_zone;

		}
	}

	// adds a zomb to the hive, parents it to the correct gameobject, and tells it if the hive is currently following the player
	public void AddZomb(GameObject zomb)
	{
		if (the_hive.Contains (zomb) != true) 
		{
			the_hive.Add (zomb);
			hive_count++;
			zomb.transform.SetParent (hive_actual.transform);
			zomb.SendMessage ("ToggleFollow", is_following);
		}
	}

	public void RemoveZomb(GameObject zomb)
	{
		if (the_hive.Contains (zomb) == true) 
		{
			zomb.SendMessage ("Release");
			the_hive.Remove (zomb);
			hive_count--;
		}
	}

	// calculates the average poaition of the hive, i.e the centre, and then updates each zomb with said position
	void UpdateHiveCentre()
	{		
		if (the_hive.Count > 0)
		{
			foreach (GameObject obj in the_hive) 
			{
				hive_centre += obj.transform.position;
			}

			hive_centre.x /= hive_count;
			hive_centre.y /= hive_count;
			hive_centre.z /= hive_count;

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
		if (Input.GetKeyDown (KeyCode.P)) 
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

			hive_actual.transform.position += move;
		}


	}
}
