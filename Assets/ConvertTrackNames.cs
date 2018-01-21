using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ConvertTrackNames : MonoBehaviour {
	
	public void ChangeNames () {
		
		var guids = AssetDatabase.FindAssets ("t:texture2D", new string[]{"Assets/Z_"});
		// var guids = AssetDatabase.FindAssets ("co l:concrete l:architecture t:texture2D", ["Assets/MyAwesomeProps"]);
		
		// foreach (var guid in guids)
			// Debug.Log (AssetDatabase.GUIDToAssetPath(guid));
		
		for (int i = 0; i < guids.Length; i++)
		{
			string path = AssetDatabase.GUIDToAssetPath(guids[i]);
			
			string spriteName = path.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries)[2].Replace(".png", "");
			
			string oldFirstLetter = spriteName.Split(new string[] {"-"}, StringSplitOptions.RemoveEmptyEntries)[0];
			string oldSecondLetter = spriteName.Split(new string[] {"-"}, StringSplitOptions.RemoveEmptyEntries)[1];
			
			string newFirstLetter = ConvertFirstLetter(oldFirstLetter);
			string newSecondLetter = "";
			
			if (oldFirstLetter == "A" || oldFirstLetter == "B")
			{
				newSecondLetter = ConvertSecondLetterHorizontal(oldSecondLetter);
			}else{
				newSecondLetter = ConvertSecondLetterVertical(oldSecondLetter);
			}
			
			string newName = newFirstLetter + "-" + newSecondLetter + ".png";
			
			Debug.Log(path + ": " + spriteName + " -> " + newName);
			
			AssetDatabase.RenameAsset(path, newName);
			// AssetDatabase.RenameAsset("Assets/Z_/A-E.png", "F-C.png");
		}
		
		
	}
	
	string ConvertFirstLetter (string letter) {
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
				return "ERROR";
		}
	}
	
	string ConvertSecondLetterHorizontal (string letter) {
		switch (letter)
		{
			case "A":
				return "F";
				
			case "B":
				return "G";
				
			case "C":
				return "E";
				
			case "D":
				return "D";
				
			case "E":
				return "C";	
				
			case "F":
				return "A";
				
			case "G":
				return "B";
				
			case "H":
				return "E";				

			case "I":
				return "I";
				
			case "J":
				return "H";
				
			default:
				return "ERROR";
		}
	}
	
	string ConvertSecondLetterVertical (string letter) {
		switch (letter)
		{
			case "A":
				return "B";
				
			case "B":
				return "A";
				
			case "C":
				return "H";
				
			case "D":
				return "I";
				
			case "E":
				return "J";		

			case "F":
				return "G";
				
			case "G":
				return "F";
				
			case "H":
				return "C";				

			case "I":
				return "D";
				
			case "J":
				return "E";
				
			default:
				return "ERROR";
		}
	}
}
