﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour {

	public int startingHealthPoints;
	public float lifeTime;

	public bool instantDeath = false;

	private int currentHealthPoints;
	[HideInInspector] public int readOnlyHealthPoints;

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

		Destroy(this.gameObject, lifeTime);
	}
}