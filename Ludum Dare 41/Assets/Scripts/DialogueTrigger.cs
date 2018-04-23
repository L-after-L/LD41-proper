using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	LayerMask mask;
	bool triggered = false;

	bool hasReset = false;

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
				hasReset = false;
				nameText.text = "Press E to talk to " + dialogue.name;

				if (Input.GetKeyDown(KeyCode.E))
				{
					TriggerDialogue();
					triggered = true;
					GameObject.Find("DialogueManager").GetComponent<DialogueManager>().setState(true);
				}
			}
		}
		else if (col == null && !hasReset)
		{
			hasReset = true;
			triggered = false;
			GameObject.Find("DialogueManager").GetComponent<DialogueManager>().setState(false);
			nameText.text = "...";
			dialogueText.text = "";
		}
	}

	public void setState(bool newState)
	{
		triggered = newState;
	}

}
