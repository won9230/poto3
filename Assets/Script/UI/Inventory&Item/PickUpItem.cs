using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
	public InventoryItemData item; //프리펩 아이템 저장
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && InventoryManager.instance.ItemSlotExceeded())
		{
			InventoryManager.instance.AddItem(item);
			Destroy(this.gameObject); //TBOB : 오브젝트 풀링으로 바꿀예정
		}
	}
}
