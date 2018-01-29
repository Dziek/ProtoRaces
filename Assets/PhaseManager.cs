using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour {
	
	public GameObject phase0Menu;
	
	[HideInInspector]
	public static int currentPhase = 0;
	
	void Phase0Complete () {
		phase0Menu.SetActive(true);
		currentPhase++;
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
