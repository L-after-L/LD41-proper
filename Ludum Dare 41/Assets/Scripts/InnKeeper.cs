using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InnKeeper : MonoBehaviour {

	public GameObject shopPanel;
	public GameObject notEnoughGoldText;
	public TextMeshProUGUI nameText;
    public TextMeshProUGUI goldText;
    public GameObject[] farms;
	public GameObject[] houses;
	//public static Inventory inventory;

	public static int totalNPC = 0;

	private bool hasReset = false;

	LayerMask mask;
	bool triggered = false;

	private void Start()
	{
		mask = LayerMask.GetMask("Player");
		totalNPC = 0;
		DisableAll();
	}

	private void Update()
	{
        goldText.text = Inventory.gold + " Gold";

		Vector2 size = new Vector2(1.5f, 1.5f);
		Collider2D col = Physics2D.OverlapBox(transform.position, size, 0f, mask);
        if (col != null)
        {
			if (col.gameObject.CompareTag("Player") && !triggered)
            {
				hasReset = false;
				nameText.text = "Press E to Open Build Shop";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    triggered = true;
                    nameText.text = "...";
                    OpenShop();
                }
            }
        }
        else if (col == null && !hasReset)
        {
            triggered = false;
			hasReset = true;
			nameText.text = "...";
			CloseShop();
        }
	}

	public void OpenShop()
	{
		shopPanel.SetActive(true);
	}

	public void BuildHouse()
	{
		if (Inventory.gold > 100)
		{
			houses[Random.Range(0, houses.Length)].SetActive(true);
			totalNPC++;
		}
		else
		{
			notEnoughGoldText.SetActive(true);
		}
	}

	public void BuildFarm()
	{
		if (Inventory.gold > 1000)
		{
			farms[Random.Range(0, farms.Length)].SetActive(true);
			totalNPC++;
		}
		else
		{
			notEnoughGoldText.SetActive(true);
		}
	}

	public void CloseShop()
	{
		shopPanel.SetActive(false);
		notEnoughGoldText.SetActive(false);
	}

	public void DisableAll()
	{
		foreach (GameObject obj in farms)
		{
			obj.SetActive(false);
		}

		foreach (GameObject obj in houses)
		{
			obj.SetActive(false);
		}
	}

}
