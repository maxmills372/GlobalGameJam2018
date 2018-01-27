using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMind : MonoBehaviour 
{

	List<GameObject> the_hive = new List<GameObject>();

	public GameObject start;

	public GameObject player;

	int hive_count = 0;
	public int start_count;

	public GameObject zomb;

	public float comfort_zone = 1.0f;

	Vector3 hive_centre;

	// Use this for initialization
	void Start () 
	{
		int j = 0;
		for (int i = 0; i < start_count; i++) 
		{
			Vector3 pos = start.transform.position;
			if (i < 50) {
				pos.x += i * 2.0f;
			} 
			else 
			{
				pos.x += i * 2.0f - 50.0f;
				j = 2;
			}
			pos.z += j;
			GameObject temp_zomb = Instantiate (zomb, pos, Quaternion.identity, transform);
			BasicZomz temp_sript = temp_zomb.GetComponent<BasicZomz> ();

			temp_sript.id = i;

			temp_sript.comfort_zone = comfort_zone;

			the_hive.Add (temp_zomb);
			hive_count++;
		}
	}

	Vector3 Repulsion(int id)
	{
		Vector3 returnVect = Vector3.zero;

		for (int b = 0; b < hive_count; b++)
		{
			if ((b != id)&&((the_hive[id].transform.position - the_hive[b].transform.position).magnitude < comfort_zone))
			{
				returnVect = returnVect - (the_hive [b].transform.position - the_hive [id].transform.position);
			}
		}
		return returnVect;
	}

	// Update is called once per frame
	void Update () 
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
