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
	private void InitSlot()                       //시작할 떄 인벤토리 초기화
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
		for (int i = 0; i < slots.Length; i++)//인벤토리에 똑같은 아이템 있으면 value 1 추가
		{
			if(slots[i].item == _item)
			{
				slots[i].item.value += 1;
				return;
			}
		}
		for (int i = 0; i < slots.Length; i++) //없으면 아이템 생성
		{
			if(slots[i].item != _item)
			{
				CheckItems(_item);
				return;
			}
		}
	}
	private void CheckItems(InventoryItemData _item) 
	{
		int i = 0;
		do
		{
			if (slots[i].item == null)                 //인벤토리 슬롯에 아이템이 없으면
			{
				slots[i].item = _item;                 //아이템 추가
				slots[i].item.value = 1;               //개수 1개
				i++;
				break;
			}
			i++;
		} while (i < itemList.Count && i < slots.Length);

		for (; i < slots.Length; i++)
		{
			slots[i].item = null;                    //남은 슬롯 null처리
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
			return;
		}
		itemBigImage.color = new Color(1, 1, 1, 1);
		itemBigImage.sprite = item.icon;
		itemDescription.text = item.itemDescription;
		itemValue.text = "개수 : " + item.value;
	}
	public void ItemUse(InventoryItemData item)
	{
		itemUse.Item(item.id);
	}
}