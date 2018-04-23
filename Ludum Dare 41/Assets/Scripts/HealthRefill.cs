using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefill : MonoBehaviour
{
	private LayerMask mask;

	private void Start()
	{
		mask = LayerMask.GetMask("Player");
	}

	private void Update()
	{
		Vector2 size = new Vector2(1.5f, 1.5f);
		Collider2D col = Physics2D.OverlapBox(transform.position, size, 0f, mask);
		if (col != null)
		{
			if (col.gameObject.CompareTag("Player"))
			{
				col.gameObject.GetComponent<Health>().setHealth(100);
			}
		}
	}
}
