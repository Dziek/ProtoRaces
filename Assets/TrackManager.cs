using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TrackManager : MonoBehaviour {

	public SpriteRenderer godTrack;
	public Sprite[] trackSprites;
	public GameObject playerGO;
		
	public struct TrackInfo {
		public string startLetter;
		public string endLetter;
		// public int number;
		public Sprite sprite;
	}
	
	public struct LetterInfo {
		public Vector2 playerPos;
		public Vector2 playerRotation;
		
		public LetterInfo (Vector2 pP, Vector2 pR) {
			playerPos = pP;
			playerRotation = pR;
		}
	}
	
	private Dictionary<string, LetterInfo> letterInfoDictionary = new Dictionary<string, LetterInfo>();
	
	private TrackInfo[] trackInfo;
	
	private string nextStartLetter = "I";
	private PolygonCollider2D pCol;
	
	private bool flipTrack;

	void Awake () {
		// trackSprites = Resources.LoadAll<Sprite>("ProtoAssets", typeof(Sprite));
		
		trackInfo = new TrackInfo[trackSprites.Length];
		for (int i = 0; i < trackSprites.Length; i++)
		{
			string spriteName = trackSprites[i].name;
			
			trackInfo[i].startLetter = spriteName.Split(new string[] {"-"}, StringSplitOptions.RemoveEmptyEntries)[0];
			trackInfo[i].endLetter = spriteName.Split(new string[] {"-"}, StringSplitOptions.RemoveEmptyEntries)[1];
			trackInfo[i].sprite = trackSprites[i];
		}
		
		LetterInfo letterA = new LetterInfo(new Vector2(-9.5f, -2), Vector2.right);
		letterInfoDictionary.Add("A", letterA);
		
		LetterInfo letterB = new LetterInfo(new Vector2(-9.5f, 2), Vector2.right);
		letterInfoDictionary.Add("B", letterB);
		
		LetterInfo letterC = new LetterInfo(new Vector2(-5, 5.75f), Vector2.down);
		letterInfoDictionary.Add("C", letterC);
		
		LetterInfo letterD = new LetterInfo(new Vector2(0, 5.75f), Vector2.down);
		letterInfoDictionary.Add("D", letterD);
		
		LetterInfo letterE = new LetterInfo(new Vector2(5, 5.75f), Vector2.down);
		letterInfoDictionary.Add("E", letterE);
		
		LetterInfo letterF = new LetterInfo(new Vector2(9.5f, -2), Vector2.left);
		letterInfoDictionary.Add("F", letterF);
		
		LetterInfo letterG = new LetterInfo(new Vector2(9.5f, 2), Vector2.left);
		letterInfoDictionary.Add("G", letterG);
		
		LetterInfo letterH = new LetterInfo(new Vector2(-5, -5.75f), Vector2.up);
		letterInfoDictionary.Add("H", letterH);
		
		LetterInfo letterI = new LetterInfo(new Vector2(0, -5.75f), Vector2.up);
		letterInfoDictionary.Add("I", letterI);
		
		LetterInfo letterJ = new LetterInfo(new Vector2(5, -5.75f), Vector2.up);
		letterInfoDictionary.Add("J", letterJ);
		
		// ChangeTrack();
	}
	
	// void Update () {
		// if (Input.GetKeyDown("space"))
		// {
			// ChangeTrack();
		// }
	// }
	
	// void UpdateScreen () {
		// ChangeTrack();
		// UpdatePlayer();
	// }
	
	void ChangeTrack () {
		
		TrackInfo[] possibleTracks = GetPossibleTracks();
		
		TrackInfo newTrack = possibleTracks[UnityEngine.Random.Range(0, possibleTracks.Length)];
		
		Sprite newTrackSprite = newTrack.sprite;
		
		godTrack.sprite = newTrackSprite;
		
		Destroy(pCol);
		pCol = godTrack.gameObject.AddComponent<PolygonCollider2D>();
		
		UpdatePlayer();
		
		nextStartLetter = GetOppositeLetter(newTrack.endLetter);	
		
		// UpdatePlayer();
	}
	
	void UpdatePlayer () {
		playerGO.transform.position = letterInfoDictionary[nextStartLetter].playerPos;
		playerGO.transform.up = letterInfoDictionary[nextStartLetter].playerRotation;
	}
	
	// TODO: Make it so cannot get same track twice?
	TrackInfo[] GetPossibleTracks () {
		return trackInfo
		.Where(n => n.startLetter == nextStartLetter)
		.Select(n => n)
		.ToArray();
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
	
	void OnEnable () {
		Messenger.AddListener("gameStart", ChangeTrack);
		Messenger.AddListener("changeTrack", ChangeTrack);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("gameStart", ChangeTrack);
		Messenger.RemoveListener("changeTrack", ChangeTrack);
	}
}
