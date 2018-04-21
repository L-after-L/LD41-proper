using UnityEngine;

public class ShootingBehaviour : MonoBehaviour {


	[Header ("Gun Specific Variables")]
	public GameObject projectilePrefab;
	public float bulletLifeTime;

	[Space]
	[Header("Shotting positions")]
	[Tooltip ("Order the positions in this order: right, up, left etc in a counter clockwise direction")]
	public Transform[] pos;

	private Transform currentMuzzlePos;
	private Transform lastMuzzlePos;

	private void Start()
	{
		currentMuzzlePos = pos[0];
	}

	private void Update()
	{
		CheckInputs();	// only works for 5 directions right now
	}

	private void CheckInputs() {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (h > 0 && v == 0){
			// player moving right
			currentMuzzlePos = pos[0];

		}
		else if (h < 0 && v == 0){
			// player moving left
			currentMuzzlePos = pos[4];
	
		}
		else if (h == 0 && v > 0) {
			// player looing up
			currentMuzzlePos = pos[2];

		} else if (h > 0 && v > 0) {
			// player looking right up
			currentMuzzlePos = pos[1];

		} else if (h < 0 && v > 0) {
			//player looking left up
			currentMuzzlePos = pos[3];

		}
		else {
			currentMuzzlePos = lastMuzzlePos;
		}

		// keep muzzle direction the same as last frame if no change has been made
		lastMuzzlePos = currentMuzzlePos;
	}

	public void Fire() {
		Destroy(Instantiate(projectilePrefab, currentMuzzlePos.position, currentMuzzlePos.rotation), bulletLifeTime);
	}
}
