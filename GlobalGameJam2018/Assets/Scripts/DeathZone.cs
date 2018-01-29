using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Zombz") 
		{
			col.gameObject.GetComponent<BasicZombz> ().DeathHasOccured ();
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
