using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

/// <summary>
/// XML���� ����
/// </summary>
public class XMLManager : MonoBehaviour
{
	public void DialogueLoadXml(Dialogue dialogue,string Xml) //Xml�ε�
	{
		dialogue.sentences.Clear();
		TextAsset textAsset = (TextAsset)Resources.Load(Xml); //Xml ���� �ε�
		//Debug.Log(textAsset);
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(textAsset.text);
		XmlNodeList nodes = xmlDoc.SelectNodes("root/worksheet/Row");
		//Debug.Log(nodes);
		foreach (XmlNode node in nodes) //Xml ��� �б�
		{
			dialogue.id = XmlConvert.ToInt32(node.SelectSingleNode("Id").InnerText);
			dialogue.name = node.SelectSingleNode("name").InnerText;
			dialogue.sentences.Add(dialogue.id, node.SelectSingleNode("sentences").InnerText);
		}
	}
}
