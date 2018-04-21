using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour {

	[Header ("Movement Variables")]
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6;

	[Space]
	[Header("Acceleration Variables")]
	public float accelerationTimeAirborne = .2f;
	public float accelerationTimeGrounded = .1f;

	[Space]
	[Header("Shooting Variables")]
	public float timeBetweenShots = 1f;

	private float timeForNextShot = 0;

	private float gravity;
	private float jumpVelocity;
	private int jumpCount = 0;
	private Vector3 velocity;
	private float velocityXSmoothing;

	private float shotCounter;

	private Controller2D controller;
	private ShootingBehaviour shoot;

	private void Start()
	{
		controller = GetComponent<Controller2D>();

		if (GetComponent<ShootingBehaviour>() != null)
		{
			shoot = GetComponent<ShootingBehaviour>();
		}
		// assign jump force based on how high the player wants to jump
		gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		//print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
		// kinematics bois
	}

	private void Update()
	{
		// reset gravity when on the ground or touching the ceiling
		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
			jumpCount = 0;
		}

		// get playerinput
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		Move(input);

		if (Input.GetKeyDown(KeyCode.J) && Time.time >= timeForNextShot)
		{
			timeForNextShot = Time.time + timeBetweenShots;
			// call shoot function in another script
			if (shoot != null)
			{
				shoot.Fire();
			}
			print("shoot");
		}
	}

	private void Move(Vector2 input) {
		// let player jump if they hit space
		// can only jump while grounded
		if ((Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) || (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 2))
		{
			velocity.y = jumpVelocity;
			jumpCount++;
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
