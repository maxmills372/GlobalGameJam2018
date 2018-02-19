using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalObject : MonoBehaviour 
{
	List<Collider> collidedObjects = new List<Collider>(); // List to hold the colliding objects

	public GameObject linked_object;

	bool activated = false;
	public int target_num;
	public int current_num;

//	void OnCollisionEnter(Collision col)
//	{
//		Debug.Log ("collision");
//		if (!collidedObjects.Contains (col.collider) && col.gameObject.tag == "Blue") 
//		{
//			collidedObjects.Add (col.collider);
//			Debug.Log ("Blue!");
//		}
//	}

//	void OnCollisionStay(Collision col)
//	{
//		OnCollisionEnter (col);
//	}
//
//	void OnCollisionExit (Collision col)
//	{
//		collidedObjects.Remove (col.collider);
//	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("hgurewa");
		if (col.tag == "Zombz") 
		{
			
			if (col.GetComponent<BasicZombz> ().activated) 
			{
				col.gameObject.SendMessage ("DeathHasOccured");
				Debug.Log ("death");
				current_num++;
				if (target_num >= current_num) 
				{
					activated = true;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		int numOfColliders = collidedObjects.Count;
		//Debug.Log (numOfColliders);

		if (activated)
		{
			Debug.Log ("buzz");
			linked_object.SendMessage ("Deactivate");
		}

		//collidedObjects.Clear ();
	}
}
