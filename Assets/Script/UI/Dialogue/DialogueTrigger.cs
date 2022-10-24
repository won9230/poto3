using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다이얼로그 어떤 XML파일과 연관 시킬지 정한다.
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialoue() //TestButton에 사용 Xml 파일 정해줌
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue,"Dialogue");
	}
}
