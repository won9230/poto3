using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
	[SerializeField] private Transform[] heart;
	[SerializeField] private Animator[] heartAnim;

	private void Start()
	{
		heart = GetComponentsInChildren<Transform>();
		heartAnim = GetComponentsInChildren<Animator>();
	}

	public void LostHeart(int i)
	{
		heartAnim[i - 1].SetTrigger("HeartLost");
		StartCoroutine(HeartSetActive(false,i));
	}
	public void GetHeart(int i)
	{
		heartAnim[i - 1].SetTrigger("HeartGet");
		StartCoroutine(HeartSetActive(true, i));
	}
	IEnumerator HeartSetActive(bool active,int i)
	{
		yield return new WaitForSeconds(0.4f);
		heart[i].gameObject.SetActive(active);
	}
}
