using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour {

	public ParticleSystem[] explode;

	// Use this for initialization
	void Start () 
	{
		// Get compenent of explosion effect
		explode = GetComponentsInChildren<ParticleSystem>();

	}
	
	void FixedUpdate()
	{
		// Check if 'a' is pressed
		if (Input.GetKeyDown ("a")) 
		{
			

			for (int i = 0; i < explode.Length; i++) 
			{
				explode [i].Play();
			}
		}

	}

}
