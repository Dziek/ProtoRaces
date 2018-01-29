using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject gameOverMenu;
	
	public GameObject playButtonGO;
	
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
		
		EventSystem.current.SetSelectedGameObject(playButtonGO);
	}
	
	void OnEnable () {
		Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("gameOver", GameOver);
		Messenger.AddListener("goToMenu", GoToMenu);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("gameOver", GameOver);
		Messenger.RemoveListener("goToMenu", GoToMenu);
	}
}
