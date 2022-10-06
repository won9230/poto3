using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
	public int id;
	public string name;

	//[TextArea(3,10)]
	//public string[] sentences;

	public Dictionary<int, string> sentences = new Dictionary<int, string>();

}
