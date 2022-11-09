using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropItem : MonoBehaviour
{
	public float shakePower = 0.08f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("��ġ");
		if (collision.CompareTag("PlayerAttack"))
		{
			//Debug.Log("PlayerAttack ��ġ");
			transform.DOShakePosition(0.1f, shakePower, 20,90,false,true,ShakeRandomnessMode.Harmonic);
		}
	}
}
