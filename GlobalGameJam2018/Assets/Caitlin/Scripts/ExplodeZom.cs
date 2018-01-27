using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeZom : MonoBehaviour {

	public Rigidbody rb;
	public GameObject redZom;

	private float radius = 5.0f;
	private float power = 10.0f;
	public Vector3 explosionPos;

	// Use this for initialization
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;

		explosionPos = redZom.transform.position;



	}
	
	void FixedUpdate()
	{
		if (Input.GetKeyDown ("a")) 
		{
			rb.isKinematic = false;
			rb.AddExplosionForce (power, explosionPos, radius, 0.0f, ForceMode.Impulse);

		}
			
	}
}
