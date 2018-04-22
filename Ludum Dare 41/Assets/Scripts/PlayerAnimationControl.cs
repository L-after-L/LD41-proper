using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationControl : MonoBehaviour {

	private Animator anim;
	private PlayerMovement movement;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		movement = GetComponent<PlayerMovement>();
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
	}
}
