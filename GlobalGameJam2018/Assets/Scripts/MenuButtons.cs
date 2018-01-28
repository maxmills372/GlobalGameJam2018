using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour 
{
	public Image teamImage;
	public Image menuImage;
	public Button playButton;
	public Button exitButton;
	CanvasGroup playCanvas;
	CanvasGroup exitCanvas;

	// Use this for initialization
	IEnumerator Start () 
	{
		// Initialise alphas
		teamImage.canvasRenderer.SetAlpha(0.0f);

		menuImage.canvasRenderer.SetAlpha(0.0f);

		playCanvas = playButton.GetComponent<CanvasGroup> ();
		playCanvas.alpha = 0.0f;
		playButton.interactable = false;

		exitCanvas = exitButton.GetComponent<CanvasGroup> ();
		exitCanvas.alpha = 0.0f;
		exitButton.interactable = false;

		// Fade 
		fadeInTeam ();
		yield return new WaitForSeconds (2.5f);
		fadeOutTeam ();
		yield return new WaitForSeconds (2.5f);
		fadeMenu ();
		yield return new WaitForSeconds (1.5f);
		buttons ();
		playButton.interactable = true;
		exitButton.interactable = true;
	}

	void fadeInTeam()
	{
		teamImage.CrossFadeAlpha (1.0f, 1.5f, false);
	}

	void fadeOutTeam()
	{
		teamImage.CrossFadeAlpha (0.0f, 1.5f, false);
	}

	void fadeMenu()
	{
		menuImage.CrossFadeAlpha (1.0f, 1.5f, false);
	}

	void buttons()
	{
		playCanvas.alpha = 1.0f;
		exitCanvas.alpha = 1.0f;
	}

	public void PlayGame () 
	{
		SceneManager.LoadScene(1);
		Debug.Log("loading the scene...");
	}

	public void ExitGame () 
	{
		Application.Quit ();
		Debug.Log ("quitting the game...");
	}
}
