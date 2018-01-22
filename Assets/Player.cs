using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private bool hasCrashed;
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name == "LevelBounds" && hasCrashed == false)
		{
			Messenger.Broadcast("changeTrack");
			Messenger.Broadcast("scoreUp");
		}
		
		// Debug.Log(other.name);
	}
	
	// void OnTriggerEnter2D (Collider2D other) {
		// // if (other.gameObject.name == "LevelBounds")
		// // {
			// // Messenger.Broadcast("changeTrack");
		// // }
		
		// Debug.Log(other.name);
	// }
	
	void OnCollisionEnter2D (Collision2D other) {
		Crash();
	}
	
	void Crash () {
		hasCrashed = true;
		Messenger.Broadcast("crash");
		
		gameObject.SetActive(false);
	}
	
	void OnEnable () {
		// gameObject.SetActive(true);
		hasCrashed = false;
	}
	
	// void OnEnable () {
		// Messenger.AddListener("gameStart", Reset);
	// }
	
	// void OnDisable () {
		// Messenger.RemoveListener("gameStart", Reset);
	// }
}
