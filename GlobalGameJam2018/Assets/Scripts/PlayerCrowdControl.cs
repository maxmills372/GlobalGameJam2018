using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrowdControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Zombz") 
		{
			//Debug.Log ("splosion");
			//col.gameObject.SendMessage ("Hello");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
