using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour {

	public int startingHealthPoints;
	public float lifeTime;

	private int currentHealthPoints;
	[HideInInspector] public int readOnlyHealthPoints;

	public bool instantDeath = false;

	private void Awake()
	{
		currentHealthPoints = startingHealthPoints;
		readOnlyHealthPoints = currentHealthPoints;
	}

	private void Update()
	{
		if (instantDeath)
		{
			Die();
		}
		readOnlyHealthPoints = currentHealthPoints;
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
