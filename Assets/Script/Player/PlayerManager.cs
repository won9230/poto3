using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	private bool inventorybool = false;
	public SpriteRenderer playerSprite; //�÷��̾� ��������Ʈ
	public GameObject inventoryObject; //�κ��丮 ������Ʈ
	public PlayerMovement playerMovement;
	public PlayerAnim anim;
	public PlayerHp playerHp; //�ν����Ϳ��� �޾ƿ�
	[SerializeField] int damageFlyingDistance = 3;

	public int hp = 10; //�÷��̾�Hp
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
		if (Input.GetKeyDown(KeyCode.E)) //�κ��丮 �¿���
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
		this.gameObject.layer = 8;    //���̾� ����
		isDamage = true;//�÷��̾� ��������	
		anim.Damage();  //������ �ִϸ��̼�
		playerHp.LostHeart(hp);
		int dirc = this.transform.position.x - pos.x > 0 ? 1 : -1;  //�÷��̾� �������� ���󰡴��� ���������� ���󰡴��� ����
		playerMovement.rb.AddForce(new Vector2(dirc, 1) * damageFlyingDistance, ForceMode2D.Impulse);
		playerSprite.color = new Color(1, 1, 1, 0.4f); //�÷��̾� ������
		StartCoroutine(OffDamaged());
	}	
	public void OnDamaged(int damage = 1)
	{
		hp -= damage;
		this.gameObject.layer = 8;    //���̾� ����
		isDamage = true;//�÷��̾� ��������	
		anim.Damage();  //������ �ִϸ��̼�
		playerHp.LostHeart(hp);
		//int dirc = this.transform.position.x - pos.x > 0 ? 1 : -1;  //�÷��̾� �������� ���󰡴��� ���������� ���󰡴��� ����
		//playerMovement.rb.AddForce(new Vector2(dirc, 1) * damageFlyingDistance, ForceMode2D.Impulse);
		playerSprite.color = new Color(1, 1, 1, 0.4f); //�÷��̾� ������
		StartCoroutine(OffDamaged());
	}
	IEnumerator OffDamaged()  //�÷��̾� ������ ���԰� ���̾� ����
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
