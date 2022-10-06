using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
	public GameObject dialougeObject;

	public void DialougeUI_On()
	{
		dialougeObject.SetActive(true);
	}	
	public void DialougeUI_Off()
	{
		dialougeObject.SetActive(false);
	}
}
