using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
	public Texture2D crosshairImage;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void OnGUI () {
		//draw on current mouse position
		float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);

		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width / 1.2f, crosshairImage.height / 1.2f), crosshairImage);
	}
}
