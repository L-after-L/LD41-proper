using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour {


	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float accelerationTimeAirborne = .2f;
	public float accelerationTimeGrounded = .1f;
	public float moveSpeed = 6;

	private float gravity;
	private float jumpVelocity;
	private Vector3 velocity;
	private float velocityXSmoothing;

	private Controller2D controller;

	private void Start()
	{
		controller = GetComponent<Controller2D>();

		// assign jump force based on how high the player wants to jump
		gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
		// kinematics bois
	}

	private void Update()
	{
		// reset gravity when on the ground or touching the ceiling
		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		// get playerinput
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Move(input);
	}

	private void Move(Vector2 input) {
		// let player jump if they hit space
		// can only jump while grounded
		if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
		{
			velocity.y = jumpVelocity;
		}

		// where the player wants to move
		float targetVelocityX = input.x * moveSpeed;

		// smoothly transition from one direction to another
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

		// add gravity 
		velocity.y += gravity * Time.deltaTime;

		// move
		controller.Move(velocity * Time.deltaTime);
	}
}
