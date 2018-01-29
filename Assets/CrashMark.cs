using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashMark : MonoBehaviour {
	
	private CrashMarkManager crashMarkManager;
	
	// Use this for initialization
	void Start () {
		crashMarkManager = GameObject.Find("Managers").GetComponent<CrashMarkManager>();
		crashMarkManager.AddToList(gameObject);
	}
	
	void GameStart () {
		//if PhaseManager.currentPhase != 7 or whatever
		gameObject.SetActive(false);
	}
	
	void GoToMenu () {
		if (PhaseManager.currentPhase == 0)
		{
			gameObject.SetActive(false);
		}
	}
	
	void OnEnable () {
		Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("goToMenu", GoToMenu);
		// Messenger.AddListener("phase0Complete", Phase0Complete);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("goToMenu", GoToMenu);
		// Messenger.RemoveListener("phase0Complete", Phase0Complete);
	}
}
