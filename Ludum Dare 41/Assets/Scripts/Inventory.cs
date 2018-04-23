using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public List<Stats> things = new List<Stats>();
	public int slots;
    [HideInInspector] public static int gold;

	public bool Add(Stats item) {
		if (things.Count >= slots)
		{
			print("No room to hold this");
			return false;
		}

		things.Add(item);
		return true;
	}

	public void Remove(Stats item) {
		things.Remove(item);
	}

    public void RemoveAll() {
        foreach (Stats item in things)
        {
            gold += item.value;
        }
        things.Clear();
        
    }
}
