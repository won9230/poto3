using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
	public GameObject npcConversation; //PlayerConversation���� �����Ѵ�.

	private void Start()
	{
		npcConversation.SetActive(false);
	}
	//public bool isConversation;
}
