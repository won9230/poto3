using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Npc����
/// </summary>
public class NpcManager : MonoBehaviour
{
	public GameObject npcConversation; //PlayerConversation���� �����Ѵ�.

	private void Start() 
	{
		npcConversation.SetActive(false); //Npc �Ӹ� ���� �ߴ� ǥ��
	}
	//public bool isConversation;
}
