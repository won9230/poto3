using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	private bool inventorybool = false;
	public SpriteRenderer playerSprite; //플레이어 스프라이트
	public GameObject inventoryObject; //인벤토리 오브젝트
	public PlayerMovement playerMovement;
	public PlayerAnim anim;
	public PlayerHp playerHp; //인스펙터에서 받아옴
	[SerializeField] int damageFlyingDistance = 3;

	public int hp = 10; //플레이어Hp
	public int MAX_HP = 10;
	public bool isDamage = false;

	private void Start()
	{
		inventoryObject.SetActive(false);
	}
	private void Update()
	{
		InventoryOnOff();
	}
	private bool Inventorybool()
	{
		return inventorybool = !inventorybool;
	}
	private void InventoryOnOff()
	{
		if (Input.GetKeyDown(KeyCode.E)) //인벤토리 온오프
		{
			inventoryObject.SetActive(Inventorybool());
			GameStop();
		}
	}
	private void GameStop()
	{
		if (!inventorybool)
		{
			Time.timeScale = 1f;
		}
		else
		{
			Time.timeScale = 0f;
		}
	}
	public void OnDamaged(Vector2 pos, int damage = 1)
	{
		hp -= damage;
		this.gameObject.layer = 8;    //레이어 변경
		isDamage = true;//플레이어 못움직임	
		anim.Damage();  //데미지 애니메이션
		playerHp.LostHeart(hp);
		int dirc = this.transform.position.x - pos.x > 0 ? 1 : -1;  //플레이어 왼쪽으로 날라가는지 오른쪽으로 날라가는지 결정
		playerMovement.rb.AddForce(new Vector2(dirc, 1) * damageFlyingDistance, ForceMode2D.Impulse);
		playerSprite.color = new Color(1, 1, 1, 0.4f); //플레이어 반투명
		StartCoroutine(OffDamaged());
	}	
	public void OnDamaged(int damage = 1)
	{
		hp -= damage;
		this.gameObject.layer = 8;    //레이어 변경
		isDamage = true;//플레이어 못움직임	
		anim.Damage();  //데미지 애니메이션
		playerHp.LostHeart(hp);
		//int dirc = this.transform.position.x - pos.x > 0 ? 1 : -1;  //플레이어 왼쪽으로 날라가는지 오른쪽으로 날라가는지 결정
		//playerMovement.rb.AddForce(new Vector2(dirc, 1) * damageFlyingDistance, ForceMode2D.Impulse);
		playerSprite.color = new Color(1, 1, 1, 0.4f); //플레이어 반투명
		StartCoroutine(OffDamaged());
	}
	IEnumerator OffDamaged()  //플레이어 데미지 안입게 레이어 변경
	{
		yield return new WaitForSeconds(0.5f);
		isDamage = false;
		yield return new WaitForSeconds(1.5f);
		this.gameObject.layer = 7;
		playerSprite.color = new Color(1, 1, 1, 1);
	}
	public void OnHeal(int heal)
	{
		int _hp = hp;
		hp += heal;
		if (MAX_HP <= hp)
		{
			hp = MAX_HP;
			playerHp.GetHeart(_hp, MAX_HP);
		}
		else if (hp <= MAX_HP)
		{
			playerHp.GetHeart(_hp,hp);
		}

	}
}
