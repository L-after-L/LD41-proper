using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnims : MonoBehaviour {

	private Health player;
	private Animator anim;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMovement>().GetComponent<Health>();

		anim = GetComponent<Animator>();
	}

	private void LateUpdate()
	{
		if (player.isDead)
		{
			anim.SetBool("isDead", true);
		}
	}
}
