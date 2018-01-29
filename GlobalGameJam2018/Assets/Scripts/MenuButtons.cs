using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour 
{


	// Use this for initialization
	void Start () 
	{
		
	}

	public void PlayGame () 
	{
		Application.LoadLevel (1);
		Debug.Log("loading the scene...");
	}

	public void ExitGame () 
	{
		Application.Quit ();
		Debug.Log ("quitting the game...");
	}
}
