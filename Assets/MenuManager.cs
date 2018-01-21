using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenu;
	
	void GameStart () {
		mainMenu.SetActive(false);
	}
	
	void OnEnable () {
		Messenger.AddListener("gameStart", GameStart);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", GameStart);
	}
}
