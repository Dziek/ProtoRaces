using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousLockScreen : MonoBehaviour {
	
	public float timeToGrow = 1.5f;
	public float delayGrow = 3f;
	
	private int noOfUnlocksNeeded;
	private int noOfUnlocksDone;
	
	protected Drag[] draggableObjects;
	protected DragContainer[] dragContainers;
	
	private Vector2[] startingScales;
	
	void Awake () {
		draggableObjects = GetComponentsInChildren<Drag>();
		dragContainers = GetComponentsInChildren<DragContainer>();
		
		noOfUnlocksNeeded = dragContainers.Length;
	}
	
	void OnEnable () {
		
		SetArrayActive(draggableObjects, false);
		SetArrayActive(dragContainers, false);
		
		Invoke("Begin", delayGrow);
	}
	
	void Begin () {
		StartCoroutine(GrowArray(draggableObjects, timeToGrow));
		StartCoroutine(GrowArray(dragContainers, timeToGrow));
	}
	
	IEnumerator GrowArray <T>(T[] arrayToGrow, float timeToGrow) where T : MonoBehaviour {
		
		SetArrayActive(arrayToGrow, true);
		
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
	
	public void ContainerFilled () {
		noOfUnlocksDone++;
		
		if (noOfUnlocksDone >= noOfUnlocksNeeded)
		{
			Debug.Log("Unlock");
			Unlock();
		}
	}
	
	public void SetArrayActive <T>(T[] array, bool setTo) where T : MonoBehaviour {
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(setTo);
		}
	}
	
	virtual public void Unlock () {
		
	}
}
