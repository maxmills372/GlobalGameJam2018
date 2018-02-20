using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplodeZom : MonoBehaviour {

	private Rigidbody rb;
	public Rigidbody[] redZom = new Rigidbody[9];
	//public Rigidbody[] bodies = new Rigidbody[9];
   

	private float radius = 5.0f;
	private float power = 10.0f;
	public Vector3 explosionPos;

	public GameObject parent_object;
	public bool blow_up;

	//public ZoneDetect zone;

	// Use this for initialization
	void Start()
	{
		blow_up = false;
		parent_object = this.gameObject.transform.parent.gameObject;



		redZom = gameObject.GetComponentsInChildren<Rigidbody>();

		/*for(int i = 0; i < 8; i++)
		{

			redZom[i] = bodies[i].gameObject;

		}*/

	}
	void FixedUpdate()
	{
		// Check if 'a' is pressed
		if (Input.GetKeyDown("l") || blow_up == true) 
		{
		

            // Set explode pos to redZom pos
            explosionPos = redZom[6].transform.position;
			parent_object.GetComponent<NavMeshAgent> ().enabled = false;
			parent_object.GetComponent<Animator> ().enabled = false;

			for (int i = 0; i < redZom.Length; i++)
            {

                // Set parent to null
				parent_object = null;


                // set kinmatic to false
                redZom[i].GetComponent<Rigidbody>().isKinematic = false;
                // Add explode force
                redZom[i].GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 0.0f, ForceMode.Impulse);
            }

			GameObject.Find("Wall_Parent").SendMessage("BLOWUP");
			blow_up = false;
        }


	}

}
