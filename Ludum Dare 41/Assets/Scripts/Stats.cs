using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Pickups/Items")]
public class Stats : ScriptableObject {

	new public string name = "new item";

	public int value = 0;

	public string description = "It's probably useful";
}
