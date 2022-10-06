using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLManager : MonoBehaviour
{
	public void DialogueLoadXml(Dialogue dialogue,string Xml) //Xml로딩
	{
		dialogue.sentences.Clear();
		TextAsset textAsset = (TextAsset)Resources.Load(Xml); //Xml 파일 로드
		//Debug.Log(textAsset);
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(textAsset.text);
		XmlNodeList nodes = xmlDoc.SelectNodes("root/worksheet/Row");
		//Debug.Log(nodes);
		foreach (XmlNode node in nodes) //Xml 요소 읽기
		{
			dialogue.id = XmlConvert.ToInt32(node.SelectSingleNode("Id").InnerText);
			dialogue.name = node.SelectSingleNode("name").InnerText;
			dialogue.sentences.Add(dialogue.id, node.SelectSingleNode("sentences").InnerText);
		}
	}
}
