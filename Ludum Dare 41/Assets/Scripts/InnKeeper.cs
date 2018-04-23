using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InnKeeper : MonoBehaviour {

	public GameObject shopPanel;
	public TextMeshProUGUI nameText;
    public TextMeshProUGUI goldText;
    public GameObject[] farms;
	public GameObject[] houses;
    //public static Inventory inventory;


	LayerMask mask;
	bool triggered = false;

	private void Start()
	{
		mask = LayerMask.GetMask("Player");
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
                nameText.text = "Press E to Open Build Shop";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    triggered = true;
                    nameText.text = "";
                    OpenShop();
                }
            }
        }
        else if (col == null && triggered)
        {
            triggered = false;
            CloseShop();
            nameText.text = "";
        }
        else {
            nameText.text = "";
        }
	}

	public void OpenShop()
	{
		shopPanel.SetActive(true);
	}

	public void BuildHouse()
	{
		houses[Random.Range(0, houses.Length)].SetActive(true);
	}

	public void BuildFarm()
	{
		farms[Random.Range(0, farms.Length)].SetActive(true);
	}

	public void CloseShop()
	{
		shopPanel.SetActive(false);
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
