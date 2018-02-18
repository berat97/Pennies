using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour {

	public Camera cam;
	// Use this for initialization
	private float maxWidth;
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector2 upperCorner = new Vector2 (Screen.width, Screen.height);
		Vector2 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float pigwidth = GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - pigwidth;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector2 targetPosition = new Vector2 (rawPosition.x, -3.5f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		GetComponent<Rigidbody2D>().MovePosition(targetPosition);
		
		targetPosition = new Vector2 (targetWidth, targetPosition.y);
		GetComponent<Rigidbody2D> ().MovePosition (targetPosition);
	}
}
