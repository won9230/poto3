using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	private bool inventorybool = false;
	public SpriteRenderer playerSprite; //�÷��̾� ��������Ʈ
	public GameObject inventoryObject; //�κ��丮 ������Ʈ
	public PlayerMovement playerMovement;
	public PlayerAnim anim;
	public PlayerHp playerHp; //�ν����Ϳ��� �޾ƿ�

	public int hp = 10; //�÷��̾�Hp
	public bool isDamage = false;

	private void Start()
	{
		inventoryObject.SetActive(false);
	}
	private void Update()
	{
		InventoryOnOff();
	}
	private bool Inventorybool()
	{
		return inventorybool = !inventorybool;
	}
	private void InventoryOnOff()
	{
		if (Input.GetKeyDown(KeyCode.E)) //�κ��丮 �¿���
		{
			inventoryObject.SetActive(Inventorybool());
			GameStop();
		}
	}
	private void GameStop()
	{
		if (!inventorybool)
		{
			Time.timeScale = 1f;
		}
		else
		{
			Time.timeScale = 0f;
		}
	}
}
