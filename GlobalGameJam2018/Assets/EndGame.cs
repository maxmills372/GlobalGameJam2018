using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	public bool increase_light;
	float count = 2.59f;
	float range = 6.5f;

	// Use this for initialization
	void Start () {
		increase_light = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(increase_light)
		{
			count += 0.1f;
			range += 0.3f;

			this.GetComponent<Light>().intensity = count;
			this.GetComponent<Light>().range = range;
		}
	}

	void OnTriggerEnter( Collider col)
	{

		if(col.tag == "Player")
		{
			increase_light = true;
		}
	}
}
