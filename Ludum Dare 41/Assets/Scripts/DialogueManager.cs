using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	bool state = false;

	Queue<string> sentences;

	private void Start()
	{
		sentences = new Queue<string>();
	}

	private void Update()
	{
		if (state && Input.GetKeyDown(KeyCode.E))
		{
			DisplayNextSentence();
		}
	}

	public void StartDialogue(Dialogue dialogue)
	{
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		//dialogueText.text = sentence;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		nameText.text = "...";
		dialogueText.text = "";
	}

	public void setState(bool newState)
	{
		state = newState;
	}

	public bool getState()
	{
		return state;
	}

}
