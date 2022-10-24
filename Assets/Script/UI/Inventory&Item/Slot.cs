using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler,IPointerExitHandler
{
	[SerializeField] private Image image;

	private InventoryItemData _item;
	public InventoryManager inventoryManager;

	public InventoryItemData item
	{
		get { return _item; }
		set
		{
			_item = value;
			if(_item != null)
			{
				image.sprite = item.icon;
				image.color = new Color(1, 1, 1, 1);
			}
			else
			{
				image.color = new Color(1, 1, 1, 0);
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("클릭");
		inventoryManager.SelectItem(item);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("들어옴");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("나감");
	}
	private void ItemUse()
	{
		inventoryManager.ItemUse(item);
	}
}
