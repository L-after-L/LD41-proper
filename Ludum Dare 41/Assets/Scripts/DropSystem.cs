using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DropSystem : MonoBehaviour {

	public Item[] possibleDrops;

	private Health myHealth;
	private bool didDrop = false;
	// Use this for initialization
	void Start () {
		myHealth = GetComponent<Health>();
	}

	private void LateUpdate()
	{
		if (myHealth.isDead)
		{
			if (possibleDrops.Length > 0)
			{
				if (!didDrop)
				{
					int rand = Random.Range(0, possibleDrops.Length - 1);

					Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y - 0.75f);

					Instantiate(possibleDrops[rand], spawnPoint, transform.rotation);

					didDrop = true;
				}
			}
		}
	}
}
