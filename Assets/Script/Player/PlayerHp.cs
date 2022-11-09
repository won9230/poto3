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

	public void LostHeart(int hp)
	{
		for (int j = 10; j > hp; j--)
		{
			heartAnim[j - 1].SetTrigger("HeartLost");
			StartCoroutine(HeartSetActive(j));
		}
	}
	public void GetHeart(int beforeHp,int afterHp)
	{
		int _beforeHp = beforeHp;
		for (; _beforeHp < afterHp; _beforeHp++)
		{
			heart[_beforeHp+1].gameObject.SetActive(true);
			heartAnim[_beforeHp].SetTrigger("HeartGet");
		}
	}
	IEnumerator HeartSetActive(int i)
	{
		yield return new WaitForSeconds(0.3f);
		heart[i].gameObject.SetActive(false);
	}
}
