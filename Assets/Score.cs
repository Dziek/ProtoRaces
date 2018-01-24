using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	private int score;
	private int highScore;
	
	void GameStart () {
		score = 0;
	}
	
	void ScoreUp () {
		score++;
	}
	
	void GameOver () {
		
		if (score > highScore)
		{
			highScore = score;
		}
		
		scoreText.text = "Score: " + score.ToString();
		highScoreText.text = "Best: " + highScore.ToString();
	}

	void OnEnable () {
		Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("scoreUp", ScoreUp);
		Messenger.AddListener("crash", GameOver);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("scoreUp", ScoreUp);
		Messenger.RemoveListener("crash", GameOver);
	}
}
