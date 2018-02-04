using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeZom : MonoBehaviour {

	private Rigidbody rb;
	public GameObject[] redZom;
    public GameObject[] wall;

	private float radius = 5.0f;
	private float power = 10.0f;
	public Vector3 explosionPos;

	//public ZoneDetect zone;

	// Use this for initialization
	void Start() 
	{
		


	}
	
	void FixedUpdate()
	{
		// Check if 'a' is pressed
		if (Input.GetKeyDown("a")) 
		{
            // Set explode pos to redZom pos
            explosionPos = redZom[6].transform.position;

            for (int i = 0; i < redZom.Length; i++)
            {
                // Set parent to null
                gameObject.transform.parent = null;
                // set kinmatic to false
                redZom[i].GetComponent<Rigidbody>().isKinematic = false;
                // Add explode force
                redZom[i].GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 0.0f, ForceMode.Impulse);
            }

            for (int i = 0; i < wall.Length; i++)
            {
                // Add explode force
                wall[i].GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 1.0f, ForceMode.Impulse);
            }

        }


	}
}
