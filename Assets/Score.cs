using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	private int score;
	
	void GameStart () {
		score = 0;
	}
	
	void ScoreUp () {
		score++;
	}

	void OnEnable () {
		Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("scoreUp", ScoreUp);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("scoreUp", ScoreUp);
	}
}
