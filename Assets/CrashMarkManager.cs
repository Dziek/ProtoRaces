using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashMarkManager : MonoBehaviour {

	private List<GameObject> crashMarks;
	
	void Awake () {
		crashMarks = new List<GameObject>();
	}
	
	public void AddToList (GameObject c) {
		crashMarks.Add(c);
	}
	
	void Phase0Complete () {
		for (int i = 0; i < crashMarks.Count; i++)
		{
			crashMarks[i].SetActive(true);
		}
	}
	
	void OnEnable () {
		// Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("phase0Complete", Phase0Complete);
	}
	
	void OnDisable () {
		// Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("phase0Complete", Phase0Complete);
	}
}
