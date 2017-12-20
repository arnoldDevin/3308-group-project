using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		var player = GameObject.FindWithTag("Player");
		if (collider.gameObject.tag == "Player") {
			player.transform.Translate(0.15f, 0, 0);
		}
	}
}
