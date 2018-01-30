using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour {
	
	public GameObject phase0Menu;
	public GameObject phase0GO;
	
	[HideInInspector]
	public static int currentPhase = 0;
	
	void Phase0Complete () {
		// phase0Menu.SetActive(true);
		GameObject go = Instantiate(phase0GO, transform.position + Vector3.forward * -5, transform.rotation);
		// Invoke("StartEndofPhase0", 2);
		currentPhase++;
	}
	
	// void StartEndofPhase0 () {
		// GameObject go = Instantiate(phase0GO, transform.position, transform.rotation);
	// }
	
	void OnEnable () {
		// Messenger.AddListener("gameStart", GameStart);
		Messenger.AddListener("phase0Complete", Phase0Complete);
	}
	
	void OnDisable () {
		// Messenger.RemoveListener("gameStart", GameStart);
		Messenger.RemoveListener("phase0Complete", Phase0Complete);
	}
}
