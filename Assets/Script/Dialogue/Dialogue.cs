using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̾�α� ���(?)
/// </summary>
[System.Serializable]
public class Dialogue //Npc��ȭ
{
	public int id; 
	public string name; //Npc�̸�

	//[TextArea(3,10)]
	//public string[] sentences;

	public Dictionary<int, string> sentences = new Dictionary<int, string>(); //Npc��� ����
}
