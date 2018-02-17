using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

	public enum zone_colour
	{
		RED,
		YELLOW,
		BLUE
	}

	public zone_colour this_zone_colour;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerStay (Collider other)
	{
		// If player is in zone
		if (other.tag == "Player")
		{
			// Check the zones colour
			// Then for the correct input
			switch (this_zone_colour)
			{
			case zone_colour.RED:
				if (Input.GetButton("Send_Red"))
				{
					// Call send red code
					print ("Send red from red zone");
				}
				break;
			case zone_colour.YELLOW:
				if (Input.GetButton("Send_Yellow"))
				{
					// Call send yellow code
					print ("Send yellow from yellow zone");
				}
				break;
			case zone_colour.BLUE:
				if (Input.GetButton("Send_Blue"))
				{
					// Call send blue code
					print ("Send blue from blue zone");
				}
				break;
			default:
				print ("There is an error with one of the zones");
				break;
			}
		}
	}
}
