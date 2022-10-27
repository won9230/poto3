using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player 애니매이션 함수
/// </summary>
public class PlayerAnim : MonoBehaviour
{
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}
	public void MoveAnim(bool b)
	{
		anim.SetBool("Move", b);
	}
	public void MoveJump(bool b)
	{
		anim.SetBool("Jump", b);
	}
	public void MoveLanding(bool b)
	{
		anim.SetBool("Landing",b);
	}
	public void MoveAttack()
	{
		anim.SetTrigger("Attack");
	}
	public void Damage()
	{
		anim.SetTrigger("Damage");
	}
}
