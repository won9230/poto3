using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QusetManager : MonoBehaviour
{
	public int qusetId;  
	public int qusetActionIndex;  //���� �����ϰ� �ִ� ����Ʈ
	public GameObject[] qusetObject; //����Ʈ�� �ʿ��� ������Ʈ���� ����

	Dictionary<int, QusetData> qusetList; //����Ʈ ���� ����

	private void Start()
	{
		qusetList = new Dictionary<int, QusetData>();
		GenerataData();
	}
	private void GenerataData() //����Ʈ ���� ����
	{
		qusetList.Add(10, new QusetData("����� ��ȭ", new int[] { 1000, 1000 }));
	}
	void NextQuset() //���� ����Ʈ �Ѿ
	{
		qusetId += 10;
		qusetActionIndex = 0;
	}
	void ControlObjext() //����Ʈ ������Ʈ ����
	{
		switch (qusetId)
		{
			case 10:
				if (qusetActionIndex == 2)
					qusetObject[0].SetActive(true);
				break;
			case 20:
				if (qusetActionIndex == 1)
					qusetObject[0].SetActive(false);
				break;
		}
	}
	public int GetQusetTalkIndex(int id) //���� ����Ʈ ��ȭ�� �Ѿ
	{
		return qusetId + qusetActionIndex;
	}
	public string CheckQuset(int id) //����Ʈ üũ
	{
		if(id == qusetList[qusetId].npcId[qusetActionIndex])
		{
			NextQuset();
			Debug.Log(qusetId);
		}
		return qusetList[qusetId].questName;
	}
	public string CheckQuset()
	{
		return qusetList[qusetId].questName;
	}
	
}
