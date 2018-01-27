using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z0MZ : MonoBehaviour {

	// The different colours
	enum Zom_Colour
	{
		GREY,
		RED,
		BLUE,
		YELLOW
	}

	Zom_Colour zom_colour;	// The colour that the zom is

	public float speed;	// The speed of the Z0M

	GameObject world_manager;	// The world manager object

	// Use this for initialization
	void Start () 
	{
		// A random number
		int rando = Random.Range(0, 10);

		// Assign random colour
		if (rando < 7)
		{
			zom_colour = Zom_Colour.GREY;
		}
		else if (rando == 7)
		{
			zom_colour = Zom_Colour.RED;
		}
		else if (rando == 8)
		{
			zom_colour = Zom_Colour.BLUE;
		}
		else if (rando == 9)
		{
			zom_colour = Zom_Colour.YELLOW;
		}
		else
		{
			print("Fuck");
		}
			
		// Find the renderer
		Renderer this_renderer = gameObject.GetComponent<Renderer>();

		// Find the manager
		world_manager = GameObject.Find("World_Manager");

		// Change colour to object colour
		switch (zom_colour)
		{
		case Zom_Colour.GREY:
			this_renderer.material.color = Color.grey;
			break;
		case Zom_Colour.RED:
			this_renderer.material.color = Color.red;
			break;
		case Zom_Colour.BLUE:
			this_renderer.material.color = Color.blue;
			break;
		case Zom_Colour.YELLOW:
			this_renderer.material.color = Color.yellow;
			break;
		default:
			// If a Z0M is black, there has been a problem
			this_renderer.material.color = Color.black;
			break;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		//find direction to centre
		Vector3 direction = (gameObject.transform.parent.position - gameObject.transform.position);

		// Move towards centre
		transform.Translate(Vector3.Normalize(direction) * speed);
	}

	// Change colour when colliding
	void OnCollisionEnter(Collision collision)
	{
		// Check if this zom is grey
		if (zom_colour == Zom_Colour.GREY)
		{
			// Check if other zom is not grey
			if(collision.collider.gameObject.GetComponent<Z0MZ>().zom_colour != Zom_Colour.GREY)
			{
				//Set colour to the colour of the other zom
				zom_colour = collision.collider.gameObject.GetComponent<Z0MZ>().zom_colour;

				// Find the renderer
				Renderer this_renderer = gameObject.GetComponent<Renderer>();

				// Change colour to object colour
				switch (zom_colour)
				{
				case Zom_Colour.GREY:
					this_renderer.material.color = Color.grey;
					break;
				case Zom_Colour.RED:
					 
					this_renderer.material.color = Color.red;
					break;
				case Zom_Colour.BLUE:
					this_renderer.material.color = Color.blue;
					break;
				case Zom_Colour.YELLOW:
					this_renderer.material.color = Color.yellow;
					break;
				default:
					this_renderer.material.color = Color.black;
					break;
				}
			}
		}
	}
}
