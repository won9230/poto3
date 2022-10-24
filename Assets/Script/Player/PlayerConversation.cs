using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player ��� ����
/// </summary>
public class PlayerConversation : MonoBehaviour
{
	//public PlayerMovement playerMovement;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			ConversationStart();
		}	
	}
	private void ConversationStart() //Npc ��ȭ ����
	{
		FindObjectOfType<DialogueTrigger>().TriggerDialoue();
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		//Debug.Log(collision);
		if (collision.CompareTag("Npc")) //Npc�� ��������� �� ǥ�� ����
		{
			//Debug.Log("Npc�� ����");
			collision.GetComponent<NpcManager>().npcConversation.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision) 
	{
		if (collision.CompareTag("Npc")) //Npc�� �������� �� ǥ�� ����
		{
			collision.GetComponent<NpcManager>().npcConversation.SetActive(false);
		}
	}
}
