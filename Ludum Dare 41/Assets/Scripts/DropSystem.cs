using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DropSystem : MonoBehaviour {

	public Item[] possibleDrops;

	private Health myHealth;

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
				int rand = Random.Range(0, possibleDrops.Length - 1);

				Instantiate(possibleDrops[rand], transform.position, transform.rotation);
			}
		}
	}
}
