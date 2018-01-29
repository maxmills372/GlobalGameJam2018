using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseKeeping : MonoBehaviour 
{
	[SerializeField]
	List<GameObject> zombz_in_area = new List<GameObject>();

	GameObject the_hive;

	bool released = false;

	// Use this for initialization
	void Start () 
	{
		the_hive = GameObject.Find ("ZombHive");
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Zombz" && zombz_in_area.Contains (col.gameObject) != true && released == false) 
		{
			zombz_in_area.Add (col.gameObject);
		}
	}
		
	public void ReleaseZombz()
	{
		foreach (GameObject obj in zombz_in_area) 
		{
			the_hive.GetComponent<HiveMind> ().RemoveZomb (obj, false);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
