using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager instance = null;
	private void Awake() //싱글톤
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Debug.LogError("싱글톤 패턴으로 InventoryManager가 지워집니다");
			Destroy(this.gameObject);
		}
	}

	public List<InventoryItemData> itemList = new List<InventoryItemData>();
	[SerializeField] private Transform slotParent;
	public Image itemBigImage;
	public Text itemDescription;
	public Text itemValue;
	private Slot[] slots;
	private ItemUse itemUse;
	public void Start()
	{
		slots = slotParent.GetComponentsInChildren<Slot>();
		itemUse = GetComponent<ItemUse>();
		InitSlot();
	}
	private void InitSlot()
	{
		foreach(Slot slot in slots)
		{
			slot.item = null;
		}
		itemBigImage.color = new Color(1,1,1,0);
		itemDescription.text = "";
	}

	public void AddItem(InventoryItemData _item) //플레이어 아이템 추가
	{
		if(ItemSlotExceeded())
		{
			itemList.Add(_item);
			ItemValue(_item);
		}
		else 
		{
			// TBOB 인게임 안에서 아이템이 가득찼습니다. 뜨기
			Debug.Log("슬롯이 가득찼습니다.");
		}
	}
	private void ItemValue(InventoryItemData _item)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if(slots[i].item == _item)
			{
				slots[i].item.value += 1;
			}
			else
			{
				checkItems();
			}
		}
	}
	private void checkItems() //플레이어 아이템 체크
	{

		int i = 0;
		for (; i < itemList.Count && i < slots.Length; i++)
		{
			slots[i].item = itemList[i];
		}
		for (; i < slots.Length; i++)
		{
			slots[i].item = null;
		}
	}
	public bool ItemSlotExceeded() //아이템 슬롯 갯수 비교
	{
		return itemList.Count < slots.Length;
	}
	public void SelectItem(InventoryItemData item) //아이템 선택시 사진,개수,아이템 설명 띄우기
	{
		if (item == null) //아이템 없으면 넘기기
		{
			Debug.Log(item);
			return;
		}
		itemBigImage.color = new Color(1, 1, 1, 1);
		itemBigImage.sprite = item.icon;
		itemDescription.text = item.itemDescription;
	}
	public void ItemUse(InventoryItemData item)
	{
		itemUse.Item(item.id);
	}
}