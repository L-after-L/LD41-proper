using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Scene mainMenu;
	public GameObject gui;

	private bool isPaused = false;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		if (gui != null)
		{
			gui.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
		{
			print("paused");
			OnPause();
		}
	}

	public void OnPause() {
		Time.timeScale = 0;
		isPaused = true;
		if (gui != null)
		{
			gui.SetActive(true);
		}
	}

	public void Resume() {
		Time.timeScale = 1;
		isPaused = false;
		if (gui != null)
		{
			gui.SetActive(false);
		}
	}

	public void QuitGame() {
		print("game exited");
		Application.Quit();
	} 
}
