using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour {

	private Inventory player;
	public LayerMask playerMask;
	public Stats stats;

	private BoxCollider2D box;
	private Bounds bounds;

	private void Awake()
	{
		box = GetComponent<BoxCollider2D>();
		bounds = box.bounds;
		player = FindObjectOfType<Inventory>().GetComponent<Inventory>();
	}

	private void Update()
	{
		DetectPlayer();
	}

	private void DetectPlayer() {
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, bounds.extents.x, playerMask);
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, bounds.extents.x, playerMask);


		if (hitRight || hitLeft)
		{
			if (hitRight && hitRight.collider.CompareTag("Player"))
			{
				ItemPickUp();
			}
			else if (hitLeft && hitLeft.collider.CompareTag("Player"))
			{
				ItemPickUp();
			}
		}
	}

	private void ItemPickUp() {
		print("picked up " + stats.name);

		bool pickedUp = player.Add(stats);

		if (pickedUp)
		{
			Destroy(this.gameObject);
		}
	}
}
