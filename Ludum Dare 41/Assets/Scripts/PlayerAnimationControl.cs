using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationControl : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if (playerInput.x > 0)
		{
			anim.SetBool("isRight", true);
		}
		else if(playerInput.x < 0)
		{
			anim.SetBool("isRight", false);
		}

		if (playerInput.y > 0)
		{
			anim.SetBool("aimUp", true);
		}
		else 
		{
			anim.SetBool("aimUp", false);
		}
	}
}
