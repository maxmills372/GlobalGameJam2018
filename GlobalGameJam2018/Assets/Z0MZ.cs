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

	// Use this for initialization
	void Start () 
	{
		// Assign random colour
		zom_colour = (Zom_Colour)Random.Range(0, 4);

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

	// Update is called once per frame
	void Update () 
	{
			
	}
}
