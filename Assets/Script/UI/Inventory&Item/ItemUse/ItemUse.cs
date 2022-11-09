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
	public void Item(InventoryItemData item) //������ ���
	{
		switch (item.id) //����ġ�� ������ �����ϰ� ���̵� �´� �Լ� ����
		{
			case 5001 :
				Item_PlusHealth(item);
				break;
			default:
				break;
		}
	}
	private void Item_PlusHealth(InventoryItemData item) //ü�� �߰� ������ 5001
	{
		//Debug.Log("�÷��̾� ü�� �߰�");
		if (player.hp < player.MAX_HP && item.value > 0)
		{
			player.OnHeal(2);
			item.value -= 1;
		}
		else if(player.hp >= player.MAX_HP)
		{
			Debug.Log("�÷��̾��� HP�� ���� á���ϴ�.");
		}
	}
}
