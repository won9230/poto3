using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
	public void Item(int id) //아이템 사용
	{
		switch (id)
		{
			default:
				break;
		}
		//TBOB : 스위치로 아이템 구분하고 아이디에 맞는 함수 실행
	}
	private void Item_PlusHealth(int id) //체력 추가 아이템
	{
		//TBOB : 플레이어 체력 추가
		Debug.Log("플레이어 체력 추가");
	}
}
