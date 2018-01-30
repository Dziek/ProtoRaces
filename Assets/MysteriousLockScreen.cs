using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousLockScreen : MonoBehaviour {
	
	// public float timeToGrow = 1.5f;
	
	private Drag[] draggableObjects;
	private DragContainer[] dragContainers;
	
	private Vector2[] startingScales;
	
	void Awake () {
		draggableObjects = GetComponentsInChildren<Drag>();
		dragContainers = GetComponentsInChildren<DragContainer>();
	}
	
	void OnEnable () {
		// StartCoroutine("Grow");
		StartCoroutine(GrowArray(draggableObjects, 1.5f));
		StartCoroutine(GrowArray(dragContainers, 1.5f));
	}
	
	IEnumerator Grow () {
		
		startingScales = new Vector2[draggableObjects.Length];
		
		for (int i = 0; i < draggableObjects.Length; i++)
		{
			startingScales[i] = draggableObjects[i].transform.localScale;
			draggableObjects[i].transform.localScale = Vector2.zero;
		}
		
		float t = 0;
		float timeToGrow = 1.5f;
		
		while (t < timeToGrow) {
				
			float scaleFactor = t / timeToGrow;	
				
			for (int i = 0; i < draggableObjects.Length; i++)
			{
				Vector2 newScale =  new Vector2(scaleFactor * startingScales[i].x, scaleFactor * startingScales[i].y);
				
				draggableObjects[i].transform.localScale = newScale;
			}
			
			t += Time.deltaTime;
			yield return null;
		}
		
		for (int i = 0; i < draggableObjects.Length; i++)
		{
			draggableObjects[i].transform.localScale = startingScales[i];
		}
	}
	
	IEnumerator GrowArray <T>(T[] arrayToGrow, float timeToGrow) where T : MonoBehaviour {
		
		startingScales = new Vector2[arrayToGrow.Length];
		
		for (int i = 0; i < arrayToGrow.Length; i++)
		{
			startingScales[i] = arrayToGrow[i].transform.localScale;
			arrayToGrow[i].transform.localScale = Vector2.zero;
		}
		
		float t = 0;
		
		while (t < timeToGrow) {
				
			float scaleFactor = t / timeToGrow;	
				
			for (int i = 0; i < arrayToGrow.Length; i++)
			{
				Vector2 newScale =  new Vector2(scaleFactor * startingScales[i].x, scaleFactor * startingScales[i].y);
				
				arrayToGrow[i].transform.localScale = newScale;
			}
			
			t += Time.deltaTime;
			yield return null;
		}
		
		for (int i = 0; i < arrayToGrow.Length; i++)
		{
			arrayToGrow[i].transform.localScale = startingScales[i];
		}
	}
}
