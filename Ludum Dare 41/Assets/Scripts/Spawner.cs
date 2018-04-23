using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public AIMovement[] enemies;

	// Use this for initialization
	void Start () {
		int rand = Random.Range(0, enemies.Length - 1);

		Instantiate(enemies[rand],transform.position, transform.rotation);	
	}
}
