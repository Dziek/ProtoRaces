using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTest : MonoBehaviour {
	
	public SpriteRenderer spriteR;
	
	public Texture2D tex;
	public Sprite test;
	private Sprite testb;
	
	void Awake () {
		// testb = test;
		
		// testb.name = "F-E";
		// spriteR.sprite = testb;
		
		testb = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 28.5f);
		
		testb.name = "F-E";
		spriteR.sprite = testb;
	}
}
