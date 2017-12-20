using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour {
	
	public Transform target;
	public float speed = 2.25f;

	bool upButton;
	bool downButton;
	bool leftButton;
	bool rightButton;

	void Update()
	{
		if(upButton)
		{
			float moveUp = (Time.deltaTime * speed);
			target.Translate(0, moveUp, 0);
		}
		else if(downButton)
		{
			float moveDown = (Time.deltaTime * speed);
			target.Translate(0, -moveDown, 0);
		}
		else if(leftButton)
		{
			float moveLeft = (Time.deltaTime * speed);
			target.Translate(-moveLeft, 0, 0);
		}
		else if(rightButton)
		{
			float moveRight = (Time.deltaTime * speed);
			target.Translate(moveRight, 0, 0);
		}
	}

	public void onUpButtonPress(bool down)
	{
		upButton = down;
	}

	public void onDownButtonPress(bool down)
	{
		downButton = down;
	}
	public void onLeftButtonPress (bool down)
	{
		leftButton= down;
	}

	public void onRightButtonPress (bool down)
	{
		rightButton = down;
	}
	
}