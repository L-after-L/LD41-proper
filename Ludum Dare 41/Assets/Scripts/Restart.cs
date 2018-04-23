using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	private Scene thisScene;

	// Use this for initialization
	void Start () {
		thisScene = SceneManager.GetActiveScene();
	}

	public void Respawn() {
		SceneManager.LoadScene(thisScene.name);
	}
}
