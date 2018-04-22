using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMovement))]
[RequireComponent(typeof(Animator))]
public class AIAnim : MonoBehaviour {

	AIMovement me;
	Animator anim;
	// Use this for initialization
	void Start () {
		me = GetComponent<AIMovement>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (me.testInput > 0)
		{
			anim.SetBool("movingRight", true);
		}
		else {
			anim.SetBool("movingRight", false);
		}

		if (me.attacked)
		{
			anim.SetBool("isAttacking", true);
		}
		else {
			anim.SetBool("isAttacking", false);
		}
	}
}
