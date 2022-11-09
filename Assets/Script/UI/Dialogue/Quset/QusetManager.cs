using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QusetManager : MonoBehaviour
{
	public int qusetId;  
	public int qusetActionIndex;  //현제 진행하고 있는 퀘스트
	public GameObject[] qusetObject; //퀘스트에 필요한 오브젝트들을 저장

	Dictionary<int, QusetData> qusetList; //퀘스트 내용 저장

	private void Start()
	{
		qusetList = new Dictionary<int, QusetData>();
		GenerataData();
	}
	private void GenerataData() //퀘스트 내용 저장
	{
		qusetList.Add(10, new QusetData("사람과 대화", new int[] { 1000, 1000 }));
	}
	void NextQuset() //다음 퀘스트 넘어감
	{
		qusetId += 10;
		qusetActionIndex = 0;
	}
	void ControlObjext() //퀘스트 오브젝트 조절
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
	public int GetQusetTalkIndex(int id) //다음 퀘스트 대화로 넘어감
	{
		return qusetId + qusetActionIndex;
	}
	public string CheckQuset(int id) //퀘스트 체크
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
