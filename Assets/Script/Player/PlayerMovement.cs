using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �÷��̾� ������ �� �⺻���� ��ƾ ����
/// </summary>
public class PlayerMovement : MonoBehaviour
{
	//private float horizontal;
	private float speed = 8f; //�̵��ӵ�
	[SerializeField] private float jumpPower = 16f; //���� �Ŀ�
	private bool isFacingRight = true; // Filp ����
	private bool isAttack = false;
	private bool isJump = false;
	private bool isStop = false;
	/*����� ����*/
	[HideInInspector] public bool inputLeft = false;
	[HideInInspector] public bool inputRight = false;
	[HideInInspector] public bool inputAttack = false;
	[HideInInspector] public bool inputJump = false;

	/*������Ʈ �� ������Ʈ*/
	//private Animator anim;
	private PlayerAnim anim;
	private Animator attackRanageAnim;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private UIButtonManager uIButton;
	[SerializeField] private GameObject attackRange;
	//[SerializeField] private GameObject npcCheakBox;

	[SerializeField] private float test; //����� �׽�Ʈ ��


	private const float JUMP_DOWN_DELAY = 0.5f;
	private void Start()
	{
		anim = GetComponent<PlayerAnim>();
		attackRanageAnim = attackRange.GetComponent<Animator>();
		uIButton.Init();
	}

	private void Update()
	{
#if (UNITY_EDITOR)
		//Debug.Log(isJump); //����� ��
		Jump();
		PlayerMove();
		Filp();
		Attack();
#elif (UNITY_IOS || UNITY_ANDROID)
		MPlayerMove();
		MJump();
#endif
	}

	private void PlayerMove() //�÷��̾� �̵�
	{
		if (Input.GetKey(KeyCode.LeftArrow)&&!isAttack) //���� ���϶� �̵� ����
		{
			RigidbodyMove(-1 * speed, rb.velocity.y);
			anim.MoveAnim(true);
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !isAttack)
		{
			RigidbodyMove(speed,rb.velocity.y);
			anim.MoveAnim(true);
		}
		else
		{
		
			RigidbodyMove(0, rb.velocity.y);
			anim.MoveAnim(false);
		}
	}

	public void Jump() //�÷��̾� ����
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded()) //���� �پ� ������ ����
		{
			RigidbodyMove(rb.velocity.x, jumpPower);
			anim.MoveJump(true);
			StartCoroutine(Jump_Down());
		}
		if (Input.GetKeyDown(KeyCode.LeftShift) && rb.velocity.y > 0f) //���� ���� ����
		{
			RigidbodyMove(rb.velocity.x, rb.velocity.y * 0.5f);
		}
		if (IsGrounded())
		{
			anim.MoveLanding(false);
			isJump = false;
		}
		else
		{
			isJump = true;
		}
	}
	private void RigidbodyMove(float x,float y)
	{
		rb.velocity = new Vector2(x, y);
	}
	IEnumerator Jump_Down() //�÷��̾� �����ϰ� �����ö�
	{
		yield return new WaitForSeconds(JUMP_DOWN_DELAY);
		anim.MoveJump(false);
		anim.MoveLanding(true);
	}
	private bool IsGrounded() //�÷��̾� �ٴ� üũ
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}
	private void Filp() //�÷��̾� �¿����
	{
		if (!isAttack)
		{
			if (isFacingRight && Input.GetKey(KeyCode.LeftArrow) || !isFacingRight && Input.GetKey(KeyCode.RightArrow)) //��ǻ�� ��ȯ
			{
				isFacingRight = !isFacingRight;
				Vector2 localScale = transform.localScale;
				localScale.x *= -1f;
				transform.localScale = localScale;
			}
			if (isFacingRight && inputLeft || !isFacingRight && inputRight) //����� ��ȯ
			{
				isFacingRight = !isFacingRight;
				Vector2 localScale = transform.localScale;
				localScale.x *= -1f;
				transform.localScale = localScale;
			}
		}
	}
	private void Attack() //�÷��̾� ����
	{
		if (Input.GetKeyDown(KeyCode.Z) && !isJump && !isAttack) //����,���� �� �϶� ���� ����
		{
			StartCoroutine(AttackTime());
			anim.MoveAttack();
			attackRanageAnim.SetTrigger("Attack"); //���� ����Ʈ
		}
	}
	IEnumerator AttackTime()
	{
		isAttack = true;
		yield return new WaitForSeconds(0.3f);
		isAttack = false;
	}
	/// <summary>
	/// �����
	/// </summary>
	private void MPlayerMove() //�÷��̾� �̵�
	{
		if (inputLeft)
		{
			rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
			anim.MoveAnim(true);
		}
		else if (inputRight)
		{
			rb.velocity = new Vector2(speed, rb.velocity.y);
			anim.MoveAnim(true);
		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
			anim.MoveAnim(false);
		}
	}
	public void MJump() //����
	{
		if (inputJump)
		{
			//Debug.Log(IsGrounded());
			if (IsGrounded())
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpPower);
			}
			else
			{
				inputJump = false;
			}
			if (rb.velocity.y > 0f)
			{
				rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.669f);
			}
		}
	}
	private void MAttack() //�÷��̾� ����� ���� (Ȯ�� ����)
	{
		if (inputAttack)
		{
			anim.MoveAttack();
		}
	}
}
