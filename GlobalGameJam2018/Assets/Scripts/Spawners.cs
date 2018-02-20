using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour 
{
	public GameObject zom_prefab;

	public List<GameObject> grey_zomz;
	public List<GameObject> red_zomz;
	public List<GameObject> blue_zomz;
	public List<GameObject> yellow_zomz;

	public int num_grey;
	public int num_red;
	public int num_blue;
	public int num_yellow;

	// Use this for initialization
	void Start () 
	{
		grey_zomz = new List<GameObject>();
		red_zomz = new List<GameObject>();
		blue_zomz = new List<GameObject>();
		yellow_zomz = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Grey
		if (grey_zomz.Count < num_grey)
		{
			grey_zomz.Add(Instantiate(zom_prefab, transform.position, Quaternion.identity));
		}

		foreach(GameObject zom in grey_zomz)
		{
			zom.GetComponent<BasicZombz>().zom_colour = BasicZombz.Zom_Colour.GREY;

			if (zom == null)
			{
				grey_zomz.Remove(zom);
			}
		}

		// Red
		if (red_zomz.Count < num_red)
		{
			red_zomz.Add(Instantiate(zom_prefab, transform.position, Quaternion.identity));
		}

		foreach(GameObject zom in red_zomz)
		{
			zom.GetComponent<BasicZombz>().zom_colour = BasicZombz.Zom_Colour.RED;
				
			if (zom == null)
			{
				red_zomz.Remove(zom);
			}
		}

		// Blue
		if (blue_zomz.Count < num_blue)
		{
			blue_zomz.Add(Instantiate(zom_prefab, transform.position, Quaternion.identity));
		}

		foreach(GameObject zom in blue_zomz)
		{
			zom.GetComponent<BasicZombz>().zom_colour = BasicZombz.Zom_Colour.BLUE;
				
			if (zom == null)
			{
				blue_zomz.Remove(zom);
			}
		}

		// Yellow
		if (yellow_zomz.Count < num_yellow)
		{
			yellow_zomz.Add(Instantiate(zom_prefab, transform.position, Quaternion.identity));
		}

		foreach(GameObject zom in yellow_zomz)
		{
			zom.GetComponent<BasicZombz>().zom_colour = BasicZombz.Zom_Colour.YELLOW;

			if (zom == null)
			{
				yellow_zomz.Remove(zom);
			}
		}
	}
}
