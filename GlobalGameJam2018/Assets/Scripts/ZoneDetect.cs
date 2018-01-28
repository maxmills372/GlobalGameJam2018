using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetect : MonoBehaviour {

	public int redNum;
	public int minNum;

	public bool isReady;
	public bool exploded; 
	public ExplodeZom[] explode_wall;
	public List<ExplodeZom> zom_explode;

	// Use this for initialization
	void Start () 
	{
		redNum = 0;
	//	minNum = 10;
		isReady = false;
		exploded = false;

		explode_wall = gameObject.transform.parent.GetComponentsInChildren<ExplodeZom>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(redNum == minNum)
		{
			isReady = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (!exploded)
		{
			if (other.gameObject.GetComponent<BasicZomz>())
			{
				if (other.gameObject.GetComponent<BasicZomz>().zom_colour == BasicZomz.Zom_Colour.RED)
				{
					redNum ++;
					zom_explode.Add(other.gameObject.GetComponent<ExplodeZom>());
					foreach (ExplodeZom this_explode in explode_wall)
					{
						this_explode.redZom = other.gameObject;
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<BasicZomz>())
		{
			if (other.gameObject.GetComponent<BasicZomz>().zom_colour == BasicZomz.Zom_Colour.RED)
			{
				redNum --;
				if (zom_explode.Contains(other.gameObject.GetComponent<ExplodeZom>()))
				{
					zom_explode.Remove(other.gameObject.GetComponent<ExplodeZom>());
				}
			}
		}
	}
}