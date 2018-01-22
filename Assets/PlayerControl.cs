using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public float startMoveSpeed = 7.5f;
	public float startRotationSpeed = 200;
	
	public float speedMultiplier;
	
	private float moveSpeed;
	private float rotSpeed;
	
	void OnEnable () {
		moveSpeed = startMoveSpeed;
		rotSpeed = startRotationSpeed;
		
		AddListeners();
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
	
	void GetFaster () {
		// moveSpeed += moveSpeedIncrease;
		// rotSpeed += rotationSpeedIncrease;
		
		moveSpeed *= speedMultiplier;
		rotSpeed *= speedMultiplier;
	}
	
	void AddListeners () {
		// Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("scoreUp", GetFaster);
	}
	
	void OnDisable () {
		// Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("scoreUp", GetFaster);
	}
}
