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

	public void Subscribe(TabButton button) //�� ��ư ����Ʈ ����
	{
		 if(tabButtons == null)
		{
			tabButtons = new List<TabButton>();
		}
		tabButtons.Add(button);
	}

	public void OnTabEnter(TabButton button) //�ǿ� ���콺 �÷��� ��
	{
		ResetTab();
		if (selectedTab == null || button != selectedTab)
		{
			button.background.sprite = tabHover;
		}
	}

	public void OnTabExit(TabButton button) //�ǿ� ���콺 ����� ��
	{
		ResetTab();
	}

	public void OnTabSelected(TabButton button) //�� Ŭ��
	{
		if(selectedTab != null) //������ �� ��ư�� ���� ��
		{
			selectedTab.Deselect(); //���� ����
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
	public void ResetTab() //�� ����
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
