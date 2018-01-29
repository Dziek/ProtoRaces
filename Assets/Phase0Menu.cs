using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Phase0Menu : MonoBehaviour {

	public Text text;
	
	private string[] script = new string[]{
			"Well.",
			"Maybe You'll Be Useful After All"
	};
	
	private int scriptStage;

	void OnEnable () {
		scriptStage = 0;
		
		text.text = script[scriptStage];
		
		// EventSystem.current.currentSelectedGameObject = GetComponentInChildren<Button>();
		EventSystem.current.SetSelectedGameObject(GetComponentInChildren<Button>().gameObject);
	}
	
	public void Next () {
		scriptStage++;
		
		if (scriptStage >= script.Length)
		{
			gameObject.SetActive(false);
			Messenger.Broadcast("goToMenu");
		}else{
			text.text = script[scriptStage];
		}
	}
}
