using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name == "LevelBounds")
		{
			Messenger.Broadcast("changeTrack");
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
}
