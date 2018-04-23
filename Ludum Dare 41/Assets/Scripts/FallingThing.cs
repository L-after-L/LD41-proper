using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
[RequireComponent(typeof(Animator))]
public class FallingThing : MonoBehaviour {

	public LayerMask targetMask;
	public LayerMask shatterMask;

	public float gravity = -6f;
	public int dmg = 25;

	private Controller2D controller;
	private Animator anim;
	private Vector2 velo;
	private bool shouldFall = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, float.MaxValue, targetMask);

		if (hit)
		{
			anim.SetBool("goTime", true);

			shouldFall = true;
		}

		if (shouldFall)
		{
			velo.y += gravity * Time.deltaTime;

			controller.Move(velo * Time.deltaTime);
		}

		hit = Physics2D.BoxCast(transform.position, this.gameObject.GetComponent<Collider2D>().bounds.size, 0, Vector2.down, velo.y * Time.deltaTime *-1f, shatterMask);
		Debug.DrawRay(transform.position, Vector2.down * velo.y * Time.deltaTime *-1f, Color.green);

		if (hit)
		{
			if (hit.collider.gameObject.GetComponent<Health>() != null)
			{
				hit.collider.gameObject.GetComponent<Health>().TakeDamage(dmg);
			}
			Destroy(this.gameObject);
		}

		anim.SetBool("goTime", false);
	}
}
