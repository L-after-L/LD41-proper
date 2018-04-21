using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public LayerMask damageMask;
	public LayerMask obsMask;
	public float speed;
	public int damage;

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.right * speed * Time.deltaTime;

		transform.position += pos;

		RaycastHit2D hit =Physics2D.Raycast(transform.position, pos, pos.magnitude, damageMask);
		if (hit)
		{
			if (hit.collider.gameObject.GetComponent<Health>() != null) {
				hit.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
				Destroy(this.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}
}
