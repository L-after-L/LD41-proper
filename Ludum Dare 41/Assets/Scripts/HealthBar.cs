using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Health hp;
    public Image healthBar; 

    private float health;
	// Use this for initialization
	void Start () {
        hp = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Health>();
        healthBar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        health = hp.readOnlyHealthPoints;
        healthBar.fillAmount = health / 100;
    }
}
