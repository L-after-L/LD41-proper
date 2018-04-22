using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class SpiderMovement : MonoBehaviour {

	[Space]
	[Header("Movement")]
	public float gravity = -6f;
	public float movementSpeed = 6f;
	public float accelerationTimeGrounded;
	public float accelerationTimeAirborne;

	private Controller2D controller;

	private Vector2 velocity;
	private float velocityXSmoothing;
	[HideInInspector]
	public float testInput = 0.5f;
	private Bounds bounds;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
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
}
