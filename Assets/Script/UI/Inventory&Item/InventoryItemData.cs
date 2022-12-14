using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject //아이템 데이터
{
	public int id;
	public string displayName;
	public Sprite icon;
	public int value;
	[TextArea(10,14)]public string itemDescription;
}
