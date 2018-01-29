using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour 
{

	public GameObject fan;
	public float speed;
	public float force;
	public float radius;

	bool active = true;

	float timer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerStay(Collider col)
	{
		if (col.GetComponent<Rigidbody> () != null && col.tag == "Zombz") 
		{
			col.GetComponent<Rigidbody> ().AddExplosionForce (force, fan.transform.position, radius);
			Debug.Log (col.name);
		} 
		else if (col.tag == "Player") 
		{
			col.SendMessage ("MoveBack", fan.transform.position);
		}
	}

	IEnumerator Slow()
	{
		active = true;
		while (speed >= 0.0f) 
		{
			speed -= Time.deltaTime * 10.0f;

			yield return null;
		}
		active = false;
		//ground.GetComponent<NavMeshSurface> ().BuildNavMesh ();
	}

	void Activate()
	{

	}

	void Deactivate()
	{
		StartCoroutine (Slow ());
		GetComponent<BoxCollider> ().enabled = false;

	}

	// Update is called once per frame
	void Update () 
	{
		if (active) 
		{
			fan.transform.Rotate (new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f));

			//Debug.Log (speed);
		}
	}
}
