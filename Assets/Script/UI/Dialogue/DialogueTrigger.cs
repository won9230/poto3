using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̾�α� � XML���ϰ� ���� ��ų�� ���Ѵ�.
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialoue() //TestButton�� ��� Xml ���� ������
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue,"Dialogue");
	}
}
