using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour 
{

	public GameObject ground;

	NavMeshSurface surface;

	// Use this for initialization
	void Start () 
	{
		ground.GetComponent<NavMeshSurface> ().BuildNavMesh ();
	}

	void Activate()
	{

	}

	void Deactivate()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
