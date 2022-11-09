using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QusetData
{
	public string questName;
	public int[] npcId;

	public QusetData(string name,int[] npc)
	{
		questName = name;
		npcId = npc;
	}
}
