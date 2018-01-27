using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour 
{
	public GameObject elevator_obj;

	public float move_distance;

	Vector3 start_pos, end_pos;

	float timer = 0.0f;

	public float speed;

	bool active = false;

	// Use this for initialization
	void Start () 
	{
		//ground.GetComponent<NavMeshSurface> ().BuildNavMesh ();
		start_pos = elevator_obj.transform.position;
		end_pos = start_pos + new Vector3 (0.0f, move_distance, 0.0f);
	}

	void Activate()
	{
		StartCoroutine (Open());
	}

	void Deactivate()
	{
		StartCoroutine (Close());
	}

	IEnumerator Close()
	{
		active = true;
		while (timer > 0.0f) 
		{
			timer -= Time.deltaTime / speed;
			yield return null;
		}
		active = false;
		//ground.GetComponent<NavMeshSurface> ().BuildNavMesh ();
	}


	IEnumerator Open()
	{
		active = true;
		while (timer <= 1.0f) 
		{
			timer += Time.deltaTime / speed;

			yield return null;
		}
		active = false;
		//ground.GetComponent<NavMeshSurface> ().BuildNavMesh ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (active) 
		{
			elevator_obj.transform.position = Vector3.Lerp (start_pos, end_pos, timer);
		}

	}
}
