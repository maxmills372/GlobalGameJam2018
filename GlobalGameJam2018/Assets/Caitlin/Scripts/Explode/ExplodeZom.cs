using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeZom : MonoBehaviour {

	private Rigidbody rb;
	public GameObject redZom;

	private float radius = 5.0f;
	private float power = 10.0f;
	public Vector3 explosionPos;

	// Use this for initialization
	void Start() 
	{
		// Set up rigidbody
		rb = GetComponent<Rigidbody>();
		// Set rigidbody to be kinimatic
		rb.isKinematic = true;

		// Set explode pos to redZom pos
		explosionPos = redZom.transform.position;
	


	}
	
	void FixedUpdate()
	{
		// Check if 'a' is pressed
		if (Input.GetKeyDown ("a")) 
		{
			// Set parent to null
			gameObject.transform.parent = null;
			// Set kinimatic to false
			rb.isKinematic = false;
			// Add explode force
			rb.AddExplosionForce (power, explosionPos, radius, 0.0f, ForceMode.Impulse);
		}
			
	}
}
