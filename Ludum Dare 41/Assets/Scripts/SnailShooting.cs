using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMovement))]
public class SnailShooting : MonoBehaviour {

	public LayerMask playerMask;
	public GameObject bullet;

	public Transform[] mouths;

	private AIMovement me;
	private bool isRight;
	private bool canSee = false;
	private bool canAtk = true;

	// Use this for initialization
	void Start () {
		me = GetComponent<AIMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (me.testInput > 0)
		{
			isRight = true;
		}
		else
		{
			isRight = false;
		}
		Transform spittingMouth;
		if (isRight)
		{
			spittingMouth = mouths[0];
		}
		else
		{
			spittingMouth = mouths[1];
		}

		RaycastHit2D hit = Physics2D.Raycast(spittingMouth.position, spittingMouth.transform.right, 10f, playerMask);
		if (hit)
		{
			canSee = true;
		}
		else
		{
			canSee = false;
			canAtk = true;
		}

		if (me.isAttacking || canSee)
		{
			if (canAtk)
			{
				Destroy(Instantiate(bullet, spittingMouth.position, spittingMouth.rotation), 3f);
				canAtk = false;
			}
		}
	}
}
