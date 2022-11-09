using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
	public InventoryItemData item; //������ ������ ����
	public GameObject Grass;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && InventoryManager.instance.ItemSlotExceeded())
		{
			InventoryManager.instance.AddItem(item);
			//Destroy(this.gameObject); //TBOB : ������Ʈ Ǯ������ �ٲܿ���
			Destroy(Grass);
		}
	}
	private void itemOn()
	{
		//TBOB : ������ ������ ������ �������� ���� + �θ� ������Ʈ�� ������ �����ϰ� �������� �����鼭 ���´�.
	}
}
