using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_BlowUP : MonoBehaviour {

	public Rigidbody[] wall;

	private float radius = 5.0f;
	private float power = 10.0f;
	public Vector3 explosionPos;

	// Use this for initialization
	void Start () {
		wall = gameObject.GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BLOWUP()
	{
		for (int i = 1; i < wall.Length; i++)
		{
			
			// Add explode force

			wall [i].GetComponent<Rigidbody> ().isKinematic = false;
			wall[i].GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(0.0f,0.0f,0.0f), radius, 1.0f, ForceMode.Impulse);
		}
	}
}
