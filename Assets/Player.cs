using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public GameObject crashEffectGO;
	public GameObject crashEffectAltGO;
	
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
		
		if (other.gameObject.tag == "Bad")
		{
			Crash();
			// Debug.Log(other.gameObject.name);
		}
	}
	
	void Crash () {
		hasCrashed = true;
		Messenger.Broadcast("crash");
		
		GameObject temp = Instantiate(GetCrashEffect(), transform.position, transform.rotation) as GameObject;
		gameObject.SetActive(false);
	}
	
	void OnEnable () {
		// gameObject.SetActive(true);
		hasCrashed = false;
	}
	
	GameObject GetCrashEffect () {
		int r = Random.Range(0, 12);
		
		if (r == 0)
		{
			return crashEffectAltGO;
		}
		
		return crashEffectGO;
	}
	
	// void OnEnable () {
		// Messenger.AddListener("gameStart", Reset);
	// }
	
	// void OnDisable () {
		// Messenger.RemoveListener("gameStart", Reset);
	// }
}
