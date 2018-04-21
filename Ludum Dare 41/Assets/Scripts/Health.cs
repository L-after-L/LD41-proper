using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int startingHealthPoints;
	public float lifeTime;

	private int currentHealthPoints;

	private void Awake()
	{
		currentHealthPoints = startingHealthPoints;
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

		GameObject.Destroy(this.gameObject, lifeTime);
	}
}
