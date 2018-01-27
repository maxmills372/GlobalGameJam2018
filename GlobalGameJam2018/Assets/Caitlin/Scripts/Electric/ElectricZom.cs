using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricZom : MonoBehaviour {

	public int blueNum;
	public int minNum;

	public bool isCharged;


	// Use this for initialization
	void Start () 
	{
		blueNum = 0;
		minNum = 10;
		isCharged = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(blueNum == minNum)
		{
			isCharged = true;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Blue")
		{
			blueNum ++;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag == "Blue")
		{
			blueNum --;
		}
	}
}
