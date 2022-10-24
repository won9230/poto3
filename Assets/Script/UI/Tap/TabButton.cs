using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour , IPointerEnterHandler, IPointerClickHandler , IPointerExitHandler
{
	public TabGroup tabGroup;

	public Image background;

	public UnityEvent onTabSelected;
	public UnityEvent onTabDeSelected;

	private void Start()
	{
		background = GetComponent<Image>();
		tabGroup.Subscribe(this);
	}

	public void Select() //�� ��ư ����
	{
		if(onTabSelected != null)
		{
			onTabSelected.Invoke(); //�̺�Ʈ ����
		}
	}
	public void Deselect() //�� �ٸ� ��ư ����
	{
		if(onTabDeSelected != null)
		{
			onTabDeSelected.Invoke(); //�̺�Ʈ ����
		}
	}
	public void OnPointerClick(PointerEventData eventData) //�� Ŭ��
	{
		tabGroup.OnTabSelected(this);
	}

	public void OnPointerEnter(PointerEventData eventData) //�ǿ� ���콺 �÷��� ��
	{
		tabGroup.OnTabEnter(this);
	}

	public void OnPointerExit(PointerEventData eventData)//�ǿ� ���콺 ����� ��
	{
		tabGroup.OnTabExit(this);
	}
}
