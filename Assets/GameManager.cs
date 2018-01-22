using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public void StartGame () {
		Messenger.Broadcast("gameStart");
	}
	
	public void GoToMenu () {
		Messenger.Broadcast("goToMenu");
	}
}
