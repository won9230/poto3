using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class DialogueManager : MonoBehaviour
{
	private XMLManager xmlManager;
	private DialogueUI dialogueUI;

	public Text nameText;
	public Text dialogueText;
	public Queue<string> sentences;
	

	private void Start()
	{
		xmlManager = GetComponent<XMLManager>();
		dialogueUI = GetComponent<DialogueUI>();
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue,string dialogueXml)
	{
		xmlManager.DialogueLoadXml(dialogue, dialogueXml);
		Debug.Log(dialogue.name + " : 대화 시작");
		dialogueUI.DialougeUI_On();
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach(string sentence in dialogue.sentences.Values)
		{
			sentences.Enqueue(sentence);
		}
		DisplayerNextSentence();
	}
	public void DisplayerNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		Debug.Log("대화 종료");
		dialogueUI.DialougeUI_Off();
	}

}
