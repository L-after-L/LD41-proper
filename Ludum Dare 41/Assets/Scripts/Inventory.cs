using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour {

    public float lifeTime = 5f;

    public TextMeshProUGUI valueText;

	public List<Stats> things = new List<Stats>();
	public int slots;
    [HideInInspector] public static int gold;
    private int value;
    private string pickUp;
    private float timeForClear = 0f;

    private void LateUpdate() {
        if (Time.time >= timeForClear)
        {
            timeForClear += lifeTime;
			if (valueText != null)
			{
				valueText.text = "";
			}
		}
    }

	public bool Add(Stats item) {
		if (things.Count >= slots)
		{
			print("No room to hold this");
			return false;
		}

		things.Add(item);
        pickUp = item.name;
        value += item.value;

        if (valueText != null)
        {
            valueText.text = "Picked Up " + pickUp + " est. value is " + value + " gold";
        }

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
		gold *= (InnKeeper.totalNPC) + 1;
        things.Clear();
        
    }
}
