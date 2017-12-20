using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Zombie") {
			Time.timeScale = 0.0f;
			Debug.Log ("You died!");
		}
	}
}
