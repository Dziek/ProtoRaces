using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase0Manager : MonoBehaviour {
	
	public GameObject phase0GO;
	
	public float delay = 3;
	
	void Awake () {
		Invoke("Begin", delay);
	}
	
	void Begin () {
		GameObject go = Instantiate(phase0GO, transform.position, transform.rotation);
	}
}
