﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
[RequireComponent(typeof(Health))]
public class AIMovement : MonoBehaviour {

	[Header("Collisions")]
	public LayerMask obsMask;

	[Space]
	[Header("Movement")]
	public float gravity = -6f;
	public float movementSpeed = 6f;
	public float accelerationTimeGrounded;
	public float accelerationTimeAirborne;

	[Space]
	[Header("Attacking")]
	public float attackTime;
	public int dmg;
	public bool isAttacking;

	[Space]
	[Header("Status")]
	public bool isDead = false;

	[HideInInspector] public bool attacked = false;
	private float prevInput;
	private float timeForAtkEnd;

	private Health myHealth;
	private Controller2D controller;

	private Vector2 velocity;
	private float velocityXSmoothing;
	[HideInInspector]public float testInput = 0.5f;
	private Bounds bounds;

	private void Awake()
	{
		controller = GetComponent<Controller2D>();
		myHealth = GetComponent<Health>();
	}

	private void Update()
	{
		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		
		if (!isDead && myHealth.readOnlyHealthPoints <= 0)
		{
			print(gameObject.name + " died");
			testInput = 0;
			isDead = true;
		}

		if (attacked && Time.time > timeForAtkEnd)
		{
			attacked = false;
			testInput = -prevInput;
		}

		CheckPath(); // check if path is okay, otherwise reverse it

		Move(); // move the object
	}

	private void Move() {
		float targetVelocityX = movementSpeed * testInput;

		//print(this.gameObject.name + " direction is " + testInput);

		// smoothly transition to the needed x input
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

		// add gravity
		velocity.y += gravity * Time.deltaTime;

		// send the movement command
		controller.Move(velocity * Time.deltaTime);
	}

	private void CheckPath() {

		// re make the CheckForObs method here
		bounds = controller.p_bounds;  // do not use this method in the future

		// find where to cast detection
		Vector2 castSize = new Vector2(bounds.extents.x - 0.2f, bounds.extents.y - 0.2f);
		Vector2 castCentre = velocity.x < 0 ? new Vector2(bounds.min.x,bounds.min.y) : new Vector2(bounds.max.x, bounds.min.y);

		// see if there is something blocking the path
		RaycastHit2D isInFront = Physics2D.Raycast(castCentre, Vector2.right * testInput, (velocity * Time.deltaTime).magnitude * 3, obsMask);
		//Debug.DrawRay(castCentre, Vector2.right * testInput * 100f, Color.cyan);
		if (isInFront)
		{
			if (isInFront.collider.name == "Player")
			{
				Attack(isInFront);
			}

			testInput = -testInput;
			return;
		}
		else {
			isAttacking = false;
		}

		//check if there is ground in front
		RaycastHit2D hit = Physics2D.BoxCast(castCentre, castSize, 0f, Vector2.down, (velocity * Time.deltaTime).magnitude, obsMask);
		//Debug.DrawRay(bounds.center, Vector2.right * testInput * 100f, Color.red);
		if (!hit)
		{
			testInput = -testInput;
			return;
		}		
	}

	private void Attack(RaycastHit2D target) {
		prevInput = testInput;
		testInput = 0;

		timeForAtkEnd = Time.time + attackTime;

		Health prey = target.collider.gameObject.GetComponent<Health>();

		if (prey != null)
		{
			print("damaged");
			prey.TakeDamage(dmg);
			isAttacking = true;
		}

		attacked = true;
	}
	
}
		
