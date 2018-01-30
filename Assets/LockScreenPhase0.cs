using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScreenPhase0 : MysteriousLockScreen {
	
	public SpriteRenderer backGround;
	public Color[] colours;
	public float timeToCycleThroughColours = 0.75f;
	
	private int colourArrayPos;
	
	override public void Unlock () {
		
		InvokeRepeating("ChangeColour", timeToCycleThroughColours, timeToCycleThroughColours);
	}
	
	void ChangeColour () {
		
		Debug.Log("Start: " + colourArrayPos);
		
		if (colourArrayPos >= colours.Length)
		{
			EndPhase();
			CancelInvoke("ChangeColour");
			return;
		}
		
		backGround.color = colours[colourArrayPos];
		colourArrayPos++;
	}
	
	void EndPhase () {
		gameObject.SetActive(false);
		Messenger.Broadcast("goToMenu");
	}
}
