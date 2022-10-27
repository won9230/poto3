using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	private bool inventorybool = false;
	public SpriteRenderer playerSprite; //플레이어 스프라이트
	public GameObject inventoryObject; //인벤토리 오브젝트
	public PlayerMovement playerMovement;
	public PlayerAnim anim;
	public PlayerHp playerHp; //인스펙터에서 받아옴

	public int hp = 10; //플레이어Hp
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
		if (Input.GetKeyDown(KeyCode.E)) //인벤토리 온오프
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
