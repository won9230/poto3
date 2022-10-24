using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� UI�� �Է� ��
/// </summary>
public class UIButtonManager : MonoBehaviour
{
	[SerializeField] GameObject player;
	PlayerMovement playerMovement;


	public void Init() 
	{
		if (player == null)
			Debug.Log("UIButtonManager�� player �� �����ϴ�.");
		playerMovement = player.GetComponent<PlayerMovement>();
	}
	public void LeftMoveDown()
	{
		playerMovement.inputLeft = true;
	}	
	public void LeftMoveUp()
	{
		playerMovement.inputLeft = false;
	}	
	public void RightMoveDown()
	{
		playerMovement.inputRight = true;
	}	
	public void RightMoveUp()
	{
		playerMovement.inputRight = false;
	}	
	public void JumpMoveDown()
	{
		playerMovement.inputJump = true;
	}	
	public void JumpMoveUp()
	{
		playerMovement.inputJump = false;
	}	
	public void AttackMoveDown()
	{
		playerMovement.inputAttack = true;
	}	
	public void AttackMoveUp()
	{
		playerMovement.inputAttack = false;
	}
}
