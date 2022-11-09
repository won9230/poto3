using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GrassItem : MonoBehaviour
{
	public float shakePower = 0.08f;
	public int hp = 3;
	[SerializeField] private GameObject itemObject;
	private SpriteRenderer sprite;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("��ġ");
		if (collision.CompareTag("PlayerAttack"))
		{
			//Debug.Log("PlayerAttack ��ġ");
			if (hp <= 1)
			{
				itemObject.SetActive(true);
				sprite.color = new Color(1, 1, 1, 0);
			}
			else
			{
				transform.DOShakePosition(0.1f, shakePower, 20, 90, false, true, ShakeRandomnessMode.Harmonic); //��鸮�� ����
				hp -= 1;
			}
		}
	}
}
