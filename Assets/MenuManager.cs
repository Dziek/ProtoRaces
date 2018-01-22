using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject gameOverMenu;
	
	void Awake () {
		mainMenu.SetActive(true);
		gameOverMenu.SetActive(false);
	}
	
	void GameStart () {
		mainMenu.SetActive(false);
		gameOverMenu.SetActive(false);
	}
	
	void GameOver () {
		gameOverMenu.SetActive(true);
	}
	
	void GoToMenu () {
		mainMenu.SetActive(true);
		gameOverMenu.SetActive(false);
	}
	
	void OnEnable () {
		Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("crash", GameOver);
		Messenger.AddListener("goToMenu", GoToMenu);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("crash", GameOver);
		Messenger.RemoveListener("goToMenu", GoToMenu);
	}
}
