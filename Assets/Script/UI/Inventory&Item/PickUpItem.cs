using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
	public InventoryItemData item; //프리펩 아이템 저장
	public GameObject Grass;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && InventoryManager.instance.ItemSlotExceeded())
		{
			InventoryManager.instance.AddItem(item);
			//Destroy(this.gameObject); //TBOB : 오브젝트 풀링으로 바꿀예정
			Destroy(Grass);
		}
	}
	private void itemOn()
	{
		//TBOB : 아이템 켜지면 아이템 떨어지는 연출 + 부모 오브젝트는 색깔을 투명하게 아이템은 켜지면서 나온다.
	}
}
