using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public GameObject interactPanel;
	public TextMeshProUGUI nameText;

	LayerMask mask;
	bool triggered = false;

	private void Start()
	{
		mask = LayerMask.GetMask("Player");
	}

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

	private void Update()
	{
		Vector2 size = new Vector2(1.5f, 1.5f);
		Collider2D col = Physics2D.OverlapBox(transform.position, size, 0f, mask);
		if (col != null)
		{
			if (col.gameObject.CompareTag("Player") && !triggered)
			{
				nameText.text = "Press E to talk to " + dialogue.name;
				interactPanel.SetActive(true);

				if (Input.GetKeyDown(KeyCode.E))
				{
					TriggerDialogue();
					triggered = true;
					interactPanel.SetActive(false);
				}
			}
		}
		else if (col == null)
		{
			triggered = false;
			interactPanel.SetActive(false);
		}
	}

	public void setState(bool newState)
	{
		triggered = newState;
	}

}
