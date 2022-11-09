using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

/// <summary>
/// ���̾�α� �Ѱ�
/// </summary>
public class DialogueManager : MonoBehaviour
{
	private XMLManager xmlManager;

	public GameObject dialougeObj; //��� UI ������Ʈ
	public Text nameText; //Npc �̸� �ؽ�Ʈ
	public Text dialogueText; //Npc ���̾�ε� �ؽ�Ʈ
	public Queue<string> sentences;

	public Dialogue dialogue;


	private void Start()
	{
		xmlManager = GetComponent<XMLManager>();
		DialogueSetActive(false);
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue,string dialogueXml) //��ȭ ����
	{
		xmlManager.DialogueLoadXml(dialogue, dialogueXml);
		DialogueSetActive(true);
		//Debug.Log(dialogue.name + " : ��ȭ ����");
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach(string sentence in dialogue.sentences.Values)
		{
			sentences.Enqueue(sentence);
		}
		DisplayerNextSentence();
	}
	public void DisplayerNextSentence() //���� ���� �Ѿ
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

	IEnumerator TypeSentence (string sentence) //�ѱ��� �� ��� ��Ÿ���� ���ش�
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	public void TriggerDialoue() //TestButton�� ��� Xml ���� ������
	{
		StartDialogue(dialogue, "XML/Dialogue");
	}
	private void EndDialogue() //��� ����
	{
		Debug.Log("��ȭ ����");
		DialogueSetActive(false);
	}
	private void DialogueSetActive(bool b) //���̾�α� UI �¿���
	{
		dialougeObj.SetActive(b);
	}

}
