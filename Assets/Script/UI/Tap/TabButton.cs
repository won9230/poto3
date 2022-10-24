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

	public void Select() //탭 버튼 선택
	{
		if(onTabSelected != null)
		{
			onTabSelected.Invoke(); //이벤트 실행
		}
	}
	public void Deselect() //탭 다른 버튼 선택
	{
		if(onTabDeSelected != null)
		{
			onTabDeSelected.Invoke(); //이벤트 실행
		}
	}
	public void OnPointerClick(PointerEventData eventData) //탭 클릭
	{
		tabGroup.OnTabSelected(this);
	}

	public void OnPointerEnter(PointerEventData eventData) //탭에 마우스 올렸을 때
	{
		tabGroup.OnTabEnter(this);
	}

	public void OnPointerExit(PointerEventData eventData)//탭에 마우스 벗어났을 때
	{
		tabGroup.OnTabExit(this);
	}
}
