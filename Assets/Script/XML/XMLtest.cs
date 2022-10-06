using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLtest : MonoBehaviour
{

	public Dialogue dialogue;
	void Start()
	{ 
		LoadXml(); 
	}
	void LoadXml() //Xml로딩
	{
		TextAsset textAsset = (TextAsset)Resources.Load("Dialogue"); //Xml 파일 로드
		//Debug.Log(textAsset);
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(textAsset.text);
		XmlNodeList nodes = xmlDoc.SelectNodes("root/worksheet/Row");
		//Debug.Log(nodes);
		foreach (XmlNode node in nodes) //Xml 요소 읽기
		{
			//Debug.Log("Id :: " + node.SelectSingleNode("Id").InnerText);
			//Debug.Log("name :: " + node.SelectSingleNode("name").InnerText);
			//Debug.Log("st :: " + node.SelectSingleNode("sentences").InnerText);
			dialogue.id = XmlConvert.ToInt32(node.SelectSingleNode("Id").InnerText);
			dialogue.name = node.SelectSingleNode("name").InnerText;
			dialogue.sentences.Add(dialogue.id, node.SelectSingleNode("sentences").InnerText);
		}
	}
}
