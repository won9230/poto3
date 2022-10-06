using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Npc관련
/// </summary>
public class NpcManager : MonoBehaviour
{
	public GameObject npcConversation; //PlayerConversation에서 제어한다.

	private void Start() 
	{
		npcConversation.SetActive(false); //Npc 머리 위에 뜨는 표시
	}
	//public bool isConversation;
}
