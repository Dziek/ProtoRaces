using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public float moveSpeed = 10;
	public float rotSpeed = 10;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Keyboard movement
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
		{
			Rotate(Input.GetAxisRaw("Horizontal"));
		}
		
		// Touch movement
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			if (mousePos.x > 0)
			{
				Rotate(1);
			}else{
				Rotate(-1);
			}
		}
		
		MoveForward();
	}
	
	void MoveForward () {
		transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
	}
	
	void Rotate (float dir) {
		transform.Rotate(Vector3.forward * (Time.deltaTime * -dir * rotSpeed));
	}
}
