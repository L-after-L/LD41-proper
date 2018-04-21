using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour {

	public int startingHealthPoints;
	public float lifeTime;

	private int currentHealthPoints;
	[HideInInspector] public int readOnlyHealthPoints;

	private void Awake()
	{
		currentHealthPoints = startingHealthPoints;
	}

<<<<<<< HEAD
=======
	private void Update()
	{
		if (instantDeath)
		{
			Die();
		}
		readOnlyHealthPoints = currentHealthPoints;
	}

>>>>>>> 15bb3361e0e33c54224e4eb36e631ec20786552d
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
