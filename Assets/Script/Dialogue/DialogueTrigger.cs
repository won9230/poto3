using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialoue() //TestButton�� ���
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue,"Dialogue");
	}
}
