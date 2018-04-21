using UnityEngine;

public class ShootingBehaviour : MonoBehaviour {

	public GameObject projectilePrefab;
	public float bulletSpeed;

	// 1 - Right, -1 - Left
	float currentDir;

	private void Start()
	{
		currentDir = 1f;
	}

	private void Update()
	{
		// Gets input.
		float h = 0; /* Input.GetAxisRaw("Horizontal-Shoot"); */
		//float v = Input.GetAxisRaw("Vertical-Shoot");

		// If h changes, current direction becomes h.
		if (h != 0f)
		{
			currentDir = h;
		}

		if (Input.GetButtonDown("Horizontal-Shoot"))
		{
			GameObject obj = Instantiate(projectilePrefab, transform.position, transform.rotation);
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			rb.velocity = obj.transform.right * bulletSpeed;
			Destroy(obj, 3f);
		}

		Flip();

	}

	private void Flip()
	{
		// If h is negative, sprite is flipped to face left and vice-versa.

		if (currentDir == -1f)
		{
			transform.rotation = Quaternion.Euler(0f,180f,0f);
		}
		else if (currentDir == 1f)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
	}

}
