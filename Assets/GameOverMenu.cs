using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit"))
		{
			Messenger.Broadcast("gameStart");
		}
		
		if (Input.GetButtonDown("Cancel"))
		{
			Messenger.Broadcast("goToMenu");
		}
	}
}
