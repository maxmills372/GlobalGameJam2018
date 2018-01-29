using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof (NavMeshSurface))]
public class PlatformNavMeshController : MonoBehaviour 
{

	NavMeshSurface nav_mesh_surface;

	// Use this for initialization
	void Start () 
	{
		nav_mesh_surface = GetComponent<NavMeshSurface> ();
		nav_mesh_surface.BuildNavMesh ();
	}

	public void RebuildNavMesh()
	{
		nav_mesh_surface.BuildNavMesh ();
	}

	// Update is called once per frame
	void Update () 
	{
		//RebuildNavMesh ();
	}
}
