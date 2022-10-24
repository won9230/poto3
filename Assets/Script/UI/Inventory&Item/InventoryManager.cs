using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager instance = null;
	private void Awake() //�̱���
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Debug.LogError("�̱��� �������� InventoryManager�� �������ϴ�");
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

	public void AddItem(InventoryItemData _item) //�÷��̾� ������ �߰�
	{
		if(ItemSlotExceeded())
		{
			itemList.Add(_item);
			ItemValue(_item);
		}
		else 
		{
			// TBOB �ΰ��� �ȿ��� �������� ����á���ϴ�. �߱�
			Debug.Log("������ ����á���ϴ�.");
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
	private void checkItems() //�÷��̾� ������ üũ
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
	public bool ItemSlotExceeded() //������ ���� ���� ��
	{
		return itemList.Count < slots.Length;
	}
	public void SelectItem(InventoryItemData item) //������ ���ý� ����,����,������ ���� ����
	{
		if (item == null) //������ ������ �ѱ��
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