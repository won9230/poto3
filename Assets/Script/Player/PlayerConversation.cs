using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private void ConversationStart()
	{
		FindObjectOfType<DialogueTrigger>().TriggerDialoue();
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		Debug.Log(collision);
		if (collision.CompareTag("Npc"))
		{
			Debug.Log("Npc¿Í Á¢ÃË");
			collision.GetComponent<NpcManager>().npcConversation.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Npc"))
		{
			collision.GetComponent<NpcManager>().npcConversation.SetActive(false);
		}
	}
}
