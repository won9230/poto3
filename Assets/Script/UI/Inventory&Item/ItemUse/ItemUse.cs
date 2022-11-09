using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
	private PlayerManager player;
	private void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
	}
	public void Item(InventoryItemData item) //아이템 사용
	{
		switch (item.id) //스위치로 아이템 구분하고 아이디에 맞는 함수 실행
		{
			case 5001 :
				Item_PlusHealth(item);
				break;
			default:
				break;
		}
	}
	private void Item_PlusHealth(InventoryItemData item) //체력 추가 아이템 5001
	{
		//Debug.Log("플레이어 체력 추가");
		if (player.hp < player.MAX_HP && item.value > 0)
		{
			player.OnHeal(2);
			item.value -= 1;
		}
		else if(player.hp >= player.MAX_HP)
		{
			Debug.Log("플레이어의 HP가 가득 찼습니다.");
		}
	}
}
