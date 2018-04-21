using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public List<Stats> things = new List<Stats>();

	public void Add(Stats item) {
		things.Add(item);
	}

	public void Remove(Stats item) {
		things.Remove(item);
	}
}
