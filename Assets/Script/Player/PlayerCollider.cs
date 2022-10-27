using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
	[SerializeField] PlayerManager playerManager;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] int damageFlyingDistance = 3;
	private int damage;


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Damage") 
		{
			OnDamaged(collision.transform.position);
		}
	}
	private void OnDamaged(Vector2 pos)
	{
		this.gameObject.layer = 8;    //레이어 변경
		playerManager.isDamage = true;//플레이어 못움직임	
		playerManager.anim.Damage();  //데미지 애니메이션
		playerManager.playerHp.LostHeart(playerManager.hp);
		playerManager.hp -= 1;
		int dirc = this.transform.position.x - pos.x > 0 ? 1 : -1;
		rb.AddForce(new Vector2(dirc, 1) * damageFlyingDistance, ForceMode2D.Impulse);
		playerManager.playerSprite.color = new Color(1, 1, 1, 0.4f);
		StartCoroutine(OffDamaged());
	}
	IEnumerator OffDamaged()
	{
		yield return new WaitForSeconds(0.5f);
		playerManager.isDamage = false;
		yield return new WaitForSeconds(1.5f);
		this.gameObject.layer = 7;
		playerManager.playerSprite.color = new Color(1, 1, 1, 1);
	}
}
