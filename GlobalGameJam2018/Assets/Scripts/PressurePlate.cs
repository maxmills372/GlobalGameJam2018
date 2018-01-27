using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour 
{

	public int max_number;

	int counter = 0;

	public GameObject display;

	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Zombz") 
		{
			counter++;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Zombz") 
		{
			counter--;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (counter >= max_number) 
		{
			display.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.green);
			target.SendMessage ("Activate");
		} 
		else 
		{
			display.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
			target.SendMessage ("Deactivate");
		}
	}
}
