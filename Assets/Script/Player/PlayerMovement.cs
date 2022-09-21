using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float horizontal;
	private float speed = 8f;
	private float jumpPower = 16f;
	private bool isFacingRight = true;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;

	private void Update()
	{
		
		//Debug.Log(IsGrounded()); //¹Ù´ÚÃ¼Å© µð¹ö±ë
		Jump();
		Filp();
	}
	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}
	private void LeftMove()
	{
		//if()
	}
	private void RightMove()
	{

	}
	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}
	private void Filp()
	{
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			isFacingRight = !isFacingRight;
			Vector2 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}
	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpPower);
		}
		if (Input.GetKeyDown(KeyCode.LeftShift) && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
	}
}
