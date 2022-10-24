using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabGroup : MonoBehaviour
{
	public List<TabButton> tabButtons;
	public Sprite tabIdle;
	public Sprite tabHover;
	public Sprite tabActive;
	public TabButton selectedTab;
	public List<GameObject> objectsToSwap;

	public void Subscribe(TabButton button) //탭 버튼 리스트 생성
	{
		 if(tabButtons == null)
		{
			tabButtons = new List<TabButton>();
		}
		tabButtons.Add(button);
	}

	public void OnTabEnter(TabButton button) //탭에 마우스 올렸을 때
	{
		ResetTab();
		if (selectedTab == null || button != selectedTab)
		{
			button.background.sprite = tabHover;
		}
	}

	public void OnTabExit(TabButton button) //탭에 마우스 벗어났을 때
	{
		ResetTab();
	}

	public void OnTabSelected(TabButton button) //탭 클릭
	{
		if(selectedTab != null) //선택한 탭 버튼이 있을 때
		{
			selectedTab.Deselect(); //선택 해제
		}
		selectedTab = button;
		selectedTab.Select();
		ResetTab();
		button.background.sprite = tabActive;
		int index = button.transform.GetSiblingIndex();
		for (int i = 0; i < objectsToSwap.Count; i++)
		{
			if(i == index)
			{
				objectsToSwap[i].SetActive(true);
			}
			else
			{
				objectsToSwap[i].SetActive(false);
			}
		}
	}
	public void ResetTab() //탭 리셋
	{
		foreach(TabButton button in tabButtons)
		{
			if(selectedTab != null && button == selectedTab)
			{
				continue;
			}
			button.background.sprite = tabIdle;
		}
	}
}
