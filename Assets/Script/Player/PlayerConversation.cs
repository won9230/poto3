using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player 대사 관련
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
	private void ConversationStart() //Npc 대화 시작
	{
		FindObjectOfType<DialogueTrigger>().TriggerDialoue();
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		//Debug.Log(collision);
		if (collision.CompareTag("Npc")) //Npc와 가까워졌을 때 표시 생성
		{
			//Debug.Log("Npc와 접촉");
			collision.GetComponent<NpcManager>().npcConversation.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision) 
	{
		if (collision.CompareTag("Npc")) //Npc와 떨어졌을 때 표시 꺼짐
		{
			collision.GetComponent<NpcManager>().npcConversation.SetActive(false);
		}
	}
}
