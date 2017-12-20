using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZombie : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet") {
			Score.scoreValue += 10;
			Destroy (gameObject);
		}
	}
}
