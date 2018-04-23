using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TeleportNode : MonoBehaviour {

	public TeleportNode destNode;
	public LayerMask teleMask;
	public PlayerMovement player;
	public bool canTele = true;

	private BoxCollider2D box;
	private float time;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMovement>();
		box = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D hit = Physics2D.OverlapBox(box.bounds.center, box.bounds.size, 0f, teleMask);
		if (hit)
		{
			if (Input.GetKeyDown(KeyCode.E) && destNode.canTele)
			{
				Vector2 destLocation = new Vector2(destNode.GetComponent<BoxCollider2D>().bounds.max.x, destNode.GetComponent<BoxCollider2D>().bounds.max.y);
				player.transform.position = destLocation;
				destNode.canTele = false;
				canTele = false;
			}
			print("in range");
		}

		if (Time.time >= time)
		{
			canTele = true;
			destNode.canTele = true;
			time += 2f;
		}
	}
}
