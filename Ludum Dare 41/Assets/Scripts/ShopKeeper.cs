﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopKeeper : MonoBehaviour {

	public GameObject shopPanel;
	public TextMeshProUGUI nameText;

    private Inventory inventory;

	private LayerMask mask;
	private bool triggered = false;

	private void Start()
	{
        inventory = FindObjectOfType<Inventory>();
		mask = LayerMask.GetMask("Player");
	}

	private void Update()
	{
		Vector2 size = new Vector2(1.5f, 1.5f);
		Collider2D col = Physics2D.OverlapBox(transform.position, size, 0f, mask);
        if (col != null)
        {
            if (col.gameObject.CompareTag("Player") && !triggered)
            {
                nameText.text = "Press E to Open Shop";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    triggered = true;
                    OpenShop();
                    nameText.text = "";
                }
            }
        }
        else if (col == null && triggered)
        {
            triggered = false;
            nameText.text = "";
            CloseShop();
        }
	}

	public void OpenShop()
	{
		shopPanel.SetActive(true);
	}

	public void Sell()
	{
        inventory.RemoveAll();
        CloseShop();
	}

	public void CloseShop()
	{
		shopPanel.SetActive(false);
	}
}