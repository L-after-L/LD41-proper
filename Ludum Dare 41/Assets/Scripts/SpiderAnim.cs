using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
public class SpiderAnim : MonoBehaviour {

	private Health myHealth;
	private Animator anim;

	// Use this for initialization
	void Start () {
		myHealth = GetComponent<Health>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (myHealth.isDead)
		{
			anim.SetBool("isDead", true);
		}
	}
}
