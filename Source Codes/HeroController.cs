using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
	public float speed = 2.25f;

	private float initialXScale;

	private Vector3 mousePos;
	private Vector3 screenPos;
	public VirtualJoystick joystick;
	// Use this for initialization
	void Start () {
		initialXScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += joystick.Horizontal() * speed * Time.deltaTime * Vector3.right;
		transform.position += joystick.Vertical() * speed * Time.deltaTime * Vector3.up;
		mousePos = Input.mousePosition;
		screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

		float angle = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg;
		if (angle < 0){
			angle = 360 + angle;
		}

		if (angle >= 90 && angle < 270){
			//mouse is LEFT of the player
			transform.localScale = new Vector3(-initialXScale, transform.localScale.y, transform.localScale.z);
		}
		else { 
			//mouse is RIGHT of the player
			transform.localScale = new Vector3(initialXScale, transform.localScale.y, transform.localScale.z);

		}
	}
}
