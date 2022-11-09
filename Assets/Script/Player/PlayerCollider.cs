using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
	[SerializeField] PlayerManager playerManager;
	[SerializeField] Rigidbody2D rb;
	private int damage;


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Damage") 
		{
			playerManager.OnDamaged(collision.transform.position);
		}
	}

}
