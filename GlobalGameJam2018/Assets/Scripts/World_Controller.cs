using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Controller : MonoBehaviour {

	public Transform[] following_zom;
	public int max_red;
	public int max_blue;
	public int max_yellow;

	// Use this for initialization
	void Start () 
	{
		following_zom = GameObject.Find("Z0MZ").GetComponentsInChildren<Transform>();

		max_red = following_zom.Length / 3;
		max_blue = max_red;
		max_yellow = following_zom.Length - max_red - max_blue;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
