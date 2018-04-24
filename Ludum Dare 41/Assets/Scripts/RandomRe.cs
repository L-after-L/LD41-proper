using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRe : MonoBehaviour {

	public float interval = 20f;

	public Spawner[] spawns;
	private int f;
	private float timeForNextSpawn = 20f;

	private void Start()
	{
		
	}


	private void Update()
	{
		if (Time.deltaTime >= timeForNextSpawn)
		{
			timeForNextSpawn += interval;
			int rand = Random.Range(0, spawns.Length - 1);

			spawns[rand].Spawn();
		}
	}
}
