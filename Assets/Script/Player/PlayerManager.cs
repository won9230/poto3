using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject inventoryObject; //인벤토리 오브젝트
	private bool inventorybool = false;

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
