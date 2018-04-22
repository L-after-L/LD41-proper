using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Health))]
public class PlayerAnimationControl : MonoBehaviour {

	private Health myHealth;
	private Animator anim;
	private PlayerMovement movement;

	private bool shouldBeActive = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		movement = GetComponent<PlayerMovement>();
		myHealth = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if (playerInput.x > 0)
		{
			anim.SetBool("isRight", true);
		}
		else if(playerInput.x < 0)
		{
			anim.SetBool("isRight", false);
		}

		anim.SetBool("isGrounded", movement.isGrounded);

		if (Input.GetAxis("Horizontal") == 0)
		{
			anim.SetBool("isIdle", true);
		}
		else
		{
			anim.SetBool("isIdle", false);
		}

		if (myHealth.isDead && shouldBeActive)
		{
			anim.SetBool("isDead", true);
			shouldBeActive = false;
		}
	}
}
