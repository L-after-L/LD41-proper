using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int startingHealthPoints;
	public float lifeTime;

	public bool instantDeath = false;

	private int currentHealthPoints;

	private void Awake()
	{
		currentHealthPoints = startingHealthPoints;
	}

	private void Update()
	{
		if (instantDeath)
		{
			Die();
		}
	}

	public void TakeDamage(int damage) {
		currentHealthPoints -= damage;
		if (currentHealthPoints <= 0)
		{
			Die();
		}
	}

	private void Die() {
		// animate death

		Destroy(this.gameObject, lifeTime);
	}
}
