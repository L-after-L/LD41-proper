using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour {

	[HideInInspector] public bool isPlayer = false;

	public int startingHealthPoints;
	public float lifeTime;
	public bool canDropItems;

	private int currentHealthPoints;
	[HideInInspector] public int readOnlyHealthPoints;
	[HideInInspector] public bool isDead = false;

	public bool instantDeath = false;

	private void Awake()
	{
		currentHealthPoints = startingHealthPoints;
		readOnlyHealthPoints = currentHealthPoints;
		if (GetComponent<PlayerMovement>() != null)
		{
			isPlayer = true;
		}
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
		if (canDropItems)
		{
			DropItem();
		}
		isDead = true;

		Destroy(this.gameObject, lifeTime);
	}

	public void DropItem() {
		print(gameObject.name + " dropped something");
	}
}
