using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TrackManager : MonoBehaviour {

	public SpriteRenderer godTrack;
	public Sprite[] trackSprites;
		
	public struct TrackInfo {
		public string startLetter;
		public string endLetter;
		// public int number;
		public Sprite sprite;
	}
	
	public struct LetterInfo {
		public Vector2 playerPos;
		public Vector2 playerRotation;
		
		public Vector2 layoutRotation;
	}
	
	private TrackInfo[] trackInfo;
	
	private string nextStartLetter = "I";
	private PolygonCollider2D pCol;
	
	private bool flipTrack;

	void Awake () {
		// trackSprites = Resources.LoadAll<Sprite>("ProtoAssets", typeof(Sprite));
		
		trackInfo = new TrackInfo[trackSprites.Length];
		for (int i = 0; i < trackSprites.Length; i++)
		{
			// trackInfo[i] = new TrackInfo();
			
			string spriteName = trackSprites[i].name;
			
			trackInfo[i].startLetter = spriteName.Split(new string[] {"-"}, StringSplitOptions.RemoveEmptyEntries)[0];
			trackInfo[i].endLetter = spriteName.Split(new string[] {"-"}, StringSplitOptions.RemoveEmptyEntries)[1];
			trackInfo[i].sprite = trackSprites[i];
		}
		
		// Debug.Log(trackInfo[17].startLetter);
		
		// ConvertNextStartLetter();
		
		// InvokeRepeating("ChangeTrack", 0, 1.5f);
		ChangeTrack();
	}
	
	void Update () {
		if (Input.GetKeyDown("space"))
		{
			ChangeTrack();
		}
	}
	
	void ChangeTrack () {
		
		TrackInfo[] possibleTracks = GetPossibleTracks();
		
		TrackInfo newTrack = possibleTracks[UnityEngine.Random.Range(0, possibleTracks.Length)];
		
		// Sprite newTrackSprite = trackSprites[Random.Range(0, 45)];
		Sprite newTrackSprite = newTrack.sprite;
		
		godTrack.sprite = newTrackSprite;
		godTrack.transform.rotation = GetRotation();
		
		Destroy(pCol);
		pCol = godTrack.gameObject.AddComponent<PolygonCollider2D>();
		
		string debugT = nextStartLetter;
		
		string flippedLetter = GetFlippedLetter(newTrack.endLetter);
		nextStartLetter = GetOppositeLetter(flippedLetter);
		// nextStartLetter = GetOppositeLetter(newTrack.endLetter);
		// ConvertNextStartLetter();
		
		// Debug.Log("New Track. EndLetter " + newTrack.endLetter);
		// Debug.Log("Get Opposite Letter " + nextStartLetter);
		// Debug.Log("Convert " + ConvertNextStartLetter());
		
		Debug.Log("This track startLetter:" + debugT
		+ " New Track endLetter:" + newTrack.endLetter
		+ " New Track flippedLetter:" + flippedLetter
		+ " Get Opposite Letter:" + nextStartLetter
		+ " Convert:" + ConvertNextStartLetter());
		
	}
	
	// TrackInfo GetNewTrack () {
	TrackInfo[] GetPossibleTracks () {
		return trackInfo
		.Where(n => n.startLetter == ConvertNextStartLetter())
		.Select(n => n)
		.ToArray();
	}
	
	string ConvertNextStartLetter () {
		switch (nextStartLetter)
		{	
			case "F":
				return "A";
				
			case "G":
				return "B";
				
			case "H":
				return "C";				

			case "I":
				return "D";
				
			case "J":
				return "E";
				
			default:
				return nextStartLetter;
		}
	}
	
	string GetFlippedLetter (string letter) {
		if (flipTrack == false)
		{
			return letter;
		}
		
		switch (letter)
		{
			case "A":
				return "B";
				
			case "B":
				return "A";
				
			case "C":
				return "E";
				
			case "D":
				return "D";
				
			case "E":
				return "C";				
				
			case "F":
				return "G";
				
			case "G":
				return "F";
				
			case "H":
				return "J";				

			case "I":
				return "I";
				
			case "J":
				return "H";
				
			default:
				return letter;
		}
	}
	
	string GetOppositeLetter (string letter) {
		switch (letter)
		{
			case "A":
				return "F";
				
			case "B":
				return "G";
				
			case "C":
				return "H";
				
			case "D":
				return "I";
				
			case "E":
				return "J";				
				
			case "F":
				return "A";
				
			case "G":
				return "B";
				
			case "H":
				return "C";				

			case "I":
				return "D";
				
			case "J":
				return "E";
				
			default:
				return nextStartLetter;
		}
	}
	
	Quaternion GetRotation () {
		switch (nextStartLetter)
		{
			case "A":
				flipTrack = false;
				return Quaternion.Euler(0, 0, 0);

			case "B":
				flipTrack = false;
				return Quaternion.Euler(0, 0, 0);	

			case "C":
				flipTrack = false;
				return Quaternion.Euler(0, 0, 0);

			case "D":
				flipTrack = false;
				return Quaternion.Euler(0, 0, 0);

			case "E":
				flipTrack = false;
				return Quaternion.Euler(0, 0, 0);

			case "F":
				flipTrack = true;
				return Quaternion.Euler(0, 180, 0);

			case "G":
				flipTrack = true;
				return Quaternion.Euler(0, 180, 0);

			case "H":
				flipTrack = true;
				return Quaternion.Euler(180, 0, 0);

			case "I":
				flipTrack = true;
				return Quaternion.Euler(180, 0, 0);

			case "J":
				flipTrack = true;
				return Quaternion.Euler(180, 0, 0);

			default:
				return transform.rotation;

		}
	}
}
