using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

/// <summary>
/// 다이얼로그 총괄
/// </summary>
public class DialogueManager : MonoBehaviour
{
	private XMLManager xmlManager;

	public GameObject dialougeObj; //대사 UI 오브젝트
	public Text nameText; //Npc 이름 텍스트
	public Text dialogueText; //Npc 다이얼로드 텍스트
	public Queue<string> sentences;

	public Dialogue dialogue;


	private void Start()
	{
		xmlManager = GetComponent<XMLManager>();
		DialogueSetActive(false);
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue,string dialogueXml) //대화 시작
	{
		xmlManager.DialogueLoadXml(dialogue, dialogueXml);
		DialogueSetActive(true);
		//Debug.Log(dialogue.name + " : 대화 시작");
		nameText.text = dialogue.name;
		sentences.Clear();

		foreach(string sentence in dialogue.sentences.Values)
		{
			sentences.Enqueue(sentence);
		}
		DisplayerNextSentence();
	}
	public void DisplayerNextSentence() //다음 대사로 넘어감
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

	IEnumerator TypeSentence (string sentence) //한글자 씩 끊어서 나타나게 해준다
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	public void TriggerDialoue() //TestButton에 사용 Xml 파일 정해줌
	{
		StartDialogue(dialogue, "XML/Dialogue");
	}
	private void EndDialogue() //대사 종료
	{
		Debug.Log("대화 종료");
		DialogueSetActive(false);
	}
	private void DialogueSetActive(bool b) //다이얼로그 UI 온오프
	{
		dialougeObj.SetActive(b);
	}

}
