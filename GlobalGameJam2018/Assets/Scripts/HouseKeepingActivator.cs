using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseKeepingActivator : MonoBehaviour 
{

	public GameObject house_keeper;

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			house_keeper.SendMessage ("ReleaseZombz");
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
