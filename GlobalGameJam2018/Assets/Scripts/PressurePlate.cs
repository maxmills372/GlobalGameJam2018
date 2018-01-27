using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour 
{

	public int max_number;

	int counter = 0;

	public GameObject display;

	public GameObject target;

	public bool detec_player;

	bool active = false;

	// Use this for initialization
	void Start () 
	{
		if (detec_player) {
			max_number = 1;
		} else {
			max_number *= 2;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Zombz" && detec_player == false) 
		{
			counter++;
			if (counter >= max_number) 
			{
				display.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.green);
				target.SendMessage ("Activate");
				active = true;
			} 
		}
		else if (col.tag == "Player" && detec_player == true) 
		{
			counter++;
			if (counter >= max_number) 
			{
				display.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.green);
				target.SendMessage ("Activate");
				active = true;
			} 
		}



	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Zombz" && detec_player == false) 
		{
			counter--;
			if(active)
			{
				display.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
				target.SendMessage ("Deactivate");
				active = false;
			}
		}
		else if (col.tag == "Player" && detec_player == true) 
		{
			counter--;
			if(active)
			{
				display.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
				target.SendMessage ("Deactivate");
				active = false;
			}
		}


	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
