using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
	public Transform Player;
	public Transform Left, Center, Right, Current, Next;
	bool moveSideways;
	public float speed, threshold;
	
	public Button[] InisibleButtons;
	
	void Start()
	{
		Current = Center;

	}
	
	void Update()
	{
		if(moveSideways)
		{
			MoveTo();
		}
		if(jump)
		{
			GoUp();
		}
		if(fall)
		{
			Fall();
		}
	}
	
	private Vector3 JumpLocation, InitLocation;
	private bool isJumping, isMoving, jump, fall;
	
	
	private void GoUp()
	{
		if(!isMoving)
		{
			isJumping = true;
			if(Vector3.Distance(Player.position, JumpLocation) > threshold)
			{
				Player.position = Vector3.Lerp(Player.position, JumpLocation, Time.deltaTime * speed);
			}
			else
			{
				jump = false;
				fall = true;
			}
		}
	}
	private void Fall()
	{
		if(!isMoving)
		{
			isJumping = true;
			if(Player.position.y - InitLocation.y > 0.1f)
			{
				Player.position = Vector3.Lerp(Player.position, InitLocation, Time.deltaTime * speed);
			}
			else
			{
				jump = false;
				fall = false;
				isJumping = false;
				ReactivateButtons();
			}
		}
	}
	
	public void Jump()
	{
		DeactivateButtons();
		InitLocation = Player.position;
		JumpLocation = Player.position + Vector3.up * 2;
		jump = true;
		fall = false;
	}
	
	void DeactivateButtons()
	{
		for (int i = 0; i < InisibleButtons.Length; i++) 
		{
			InisibleButtons[i].interactable = false;
		}
	}
	
	void ReactivateButtons()
	{
		for (int i = 0; i < InisibleButtons.Length; i++) 
		{
			InisibleButtons[i].interactable = true;
		}
	}
	
	void MoveTo()
	{
		if(Vector3.Distance(Player.position, Next.position) > threshold)
		{
			Player.position = Vector3.Lerp(Player.position, Next.position, Time.deltaTime * speed);
		}
		else
		{
			Current = Next;
			Next = null;
			moveSideways = false;
			isMoving = false;
			ReactivateButtons();
		}
	}
	
	public void GoRight()
	{
		DeactivateButtons();
		isMoving = true;
		//Debug.Log("going right");
		if(!isJumping)
		{
			if(Current == Left)
			{
				Next = Center;
				moveSideways = true;
			}
			if(Current == Center)
			{
				Next = Right;
				moveSideways = true;
			}
		}
	}
	
	public void GoLeft()
	{
		DeactivateButtons();
		isMoving = true;
		//Debug.Log("going left");
		if(!isJumping)
		{
			if(Current == Center)
			{
				Next = Left;
				moveSideways = true;
			}
			if(Current == Right	)
			{
				Next = Center;
				moveSideways = true;
			}
		}
	}
}
