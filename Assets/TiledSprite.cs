using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledSprite : MonoBehaviour {
	
	public Sprite[] sprites;
	
	public SpriteRenderer otherSR;
	private SpriteRenderer sR;
	
	void Awake () {
		sR = GetComponent<SpriteRenderer>();
	}
	
	void ChangedTrack () {
		
		Sprite newSprite = sprites[Random.Range(0, sprites.Length)];
		
		sR.sprite = newSprite;
		otherSR.sprite = newSprite;
	}
	
	void OnEnable () {
		Messenger.AddListener("gameStart", ChangedTrack);
		Messenger.AddListener("changeTrack", ChangedTrack);
		// Messenger.AddListener("goToMenu", GoToMenu);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", ChangedTrack);
		Messenger.RemoveListener("changeTrack", ChangedTrack);
		// Messenger.RemoveListener("goToMenu", GoToMenu);
	}
}
