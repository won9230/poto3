using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다이얼로그 모듈(?)
/// </summary>
[System.Serializable]
public class Dialogue //Npc대화
{
	public int id; 
	public string name; //Npc이름

	//[TextArea(3,10)]
	//public string[] sentences;

	public Dictionary<int, string> sentences = new Dictionary<int, string>(); //Npc대사 내용
}
