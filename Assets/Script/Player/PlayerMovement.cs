using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 플레이어 움직임 및 기본적은 루틴 관련
/// </summary>
public class PlayerMovement : MonoBehaviour
{
	//private float horizontal;
	private float speed = 8f; //이동속도
	[SerializeField] private float jumpPower = 16f; //점프 파워
	private bool isFacingRight = true; // Filp 관련
	private bool isAttack = false;
	private bool isJump = false;
	private bool isStop = false;
	/*모바일 관련*/
	[HideInInspector] public bool inputLeft = false;
	[HideInInspector] public bool inputRight = false;
	[HideInInspector] public bool inputAttack = false;
	[HideInInspector] public bool inputJump = false;

	/*컴포넌트 밑 오브젝트*/
	//private Animator anim;
	private PlayerAnim anim;
	private Animator attackRanageAnim;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private UIButtonManager uIButton;
	[SerializeField] private GameObject attackRange;
	//[SerializeField] private GameObject npcCheakBox;

	[SerializeField] private float test; //디버그 테스트 용


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
		//Debug.Log(isJump); //디버깅 용
		Jump();
		PlayerMove();
		Filp();
		Attack();
#elif (UNITY_IOS || UNITY_ANDROID)
		MPlayerMove();
		MJump();
#endif
	}

	private void PlayerMove() //플레이어 이동
	{
		if (Input.GetKey(KeyCode.LeftArrow)&&!isAttack) //공격 중일때 이동 못함
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

	public void Jump() //플레이어 점프
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded()) //땅에 붙어 있으면 점프
		{
			RigidbodyMove(rb.velocity.x, jumpPower);
			anim.MoveJump(true);
			StartCoroutine(Jump_Down());
		}
		if (Input.GetKeyDown(KeyCode.LeftShift) && rb.velocity.y > 0f) //점프 높이 조절
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
	IEnumerator Jump_Down() //플레이어 점프하고 내려올때
	{
		yield return new WaitForSeconds(JUMP_DOWN_DELAY);
		anim.MoveJump(false);
		anim.MoveLanding(true);
	}
	private bool IsGrounded() //플레이어 바닥 체크
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}
	private void Filp() //플레이어 좌우반전
	{
		if (!isAttack)
		{
			if (isFacingRight && Input.GetKey(KeyCode.LeftArrow) || !isFacingRight && Input.GetKey(KeyCode.RightArrow)) //컴퓨터 전환
			{
				isFacingRight = !isFacingRight;
				Vector2 localScale = transform.localScale;
				localScale.x *= -1f;
				transform.localScale = localScale;
			}
			if (isFacingRight && inputLeft || !isFacingRight && inputRight) //모바일 전환
			{
				isFacingRight = !isFacingRight;
				Vector2 localScale = transform.localScale;
				localScale.x *= -1f;
				transform.localScale = localScale;
			}
		}
	}
	private void Attack() //플레이어 공격
	{
		if (Input.GetKeyDown(KeyCode.Z) && !isJump && !isAttack) //점프,공격 중 일때 공격 못함
		{
			StartCoroutine(AttackTime());
			anim.MoveAttack();
			attackRanageAnim.SetTrigger("Attack"); //공격 이펙트
		}
	}
	IEnumerator AttackTime()
	{
		isAttack = true;
		yield return new WaitForSeconds(0.3f);
		isAttack = false;
	}
	/// <summary>
	/// 모바일
	/// </summary>
	private void MPlayerMove() //플레이어 이동
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
	public void MJump() //점프
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
	private void MAttack() //플레이어 모바일 공격 (확인 안함)
	{
		if (inputAttack)
		{
			anim.MoveAttack();
		}
	}
}
