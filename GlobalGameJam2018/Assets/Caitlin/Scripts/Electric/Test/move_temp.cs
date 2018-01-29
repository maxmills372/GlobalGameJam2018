using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_temp : MonoBehaviour {

	public GameObject moveObj;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("w"))
		{
			moveObj.transform.Translate(new Vector3(0.0f, 0.0f, 1.0f) * 0.1f);
		}

		if(Input.GetKey("s"))
		{
			moveObj.transform.Translate( new Vector3(0.0f, 0.0f, -1.0f) * 0.1f);
		}
	}
}
