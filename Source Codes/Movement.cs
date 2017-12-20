using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {
	
	float directionX;
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		directionX = CrossPlatformInputManager.GetAxis("Horizontal");
		rb.velocity = new Vector2(directionX * 10, 0);
	}
}
