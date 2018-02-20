using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour 
{

	GameObject hive_mind;

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
		hive_mind = GameObject.Find("ZombHive");
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}
		
	void OnTriggerStay (Collider other)
	{
		// If player is in zone
		if (other.tag == "Player" && Input.GetButtonDown("Send_Zombz"))
		{
			// Check the zones colour
			// Then for the correct input
			switch (this_zone_colour)
			{
			case zone_colour.RED:
					// Call send red code
				print ("Send red from red zone");

				hive_mind.GetComponent<HiveMind> ().RedZombEffect (this.gameObject, 3);

					
				//StartCoroutine (Boom());
					break;

				case zone_colour.YELLOW:					
					// Call send yellow code
					print ("Send yellow from yellow zone");

				GameObject.Find("BridgeController").GetComponent<BridgeFormation>().Form_Bridge();
					break;

				case zone_colour.BLUE:				
					// Call send blue code
					print ("Send blue from blue zone");
				hive_mind.GetComponent<HiveMind> ().BlueZombEffect (this.gameObject, 5);
					break;

				default:
					print ("There is an error with one of the zones");
					break;
			}
		}
	}

	IEnumerator Boom()
	{
		yield return new WaitForSeconds (1.0f);

		yield return new WaitForSeconds (1.0f);

		yield return new WaitForSeconds (1.0f);


		hive_mind.GetComponent<HiveMind> ().Boom();
		yield return null;

	}
}
