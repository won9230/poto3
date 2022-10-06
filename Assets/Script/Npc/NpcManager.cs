using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
	public GameObject npcConversation; //PlayerConversation에서 제어한다.

	private void Start()
	{
		npcConversation.SetActive(false);
	}
	//public bool isConversation;
}
