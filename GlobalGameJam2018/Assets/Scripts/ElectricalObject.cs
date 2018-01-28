using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalObject : MonoBehaviour 
{
	List<Collider> collidedObjects = new List<Collider>(); // List to hold the colliding objects

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("collision");
		if (!collidedObjects.Contains (col.collider) && col.gameObject.tag == "Blue") 
		{
			collidedObjects.Add (col.collider);
			Debug.Log ("Blue!");
		}
	}

	void OnCollisionStay(Collision col)
	{
		OnCollisionEnter (col);
	}

	void OnCollisionExit (Collision col)
	{
		collidedObjects.Remove (col.collider);
	}
	
	// Update is called once per frame
	void Update () 
	{
		int numOfColliders = collidedObjects.Count;
		Debug.Log (numOfColliders);

		if (numOfColliders >= 5)
		{
			Debug.Log ("buzz");
		//	do the thing
		}

		//collidedObjects.Clear ();
	}
}
