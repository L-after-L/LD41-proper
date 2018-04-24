using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public int f;

	public void GO() {
		SceneManager.LoadScene(1);
	}
}
