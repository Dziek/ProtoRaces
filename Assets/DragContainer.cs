using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragContainer : MonoBehaviour {
	
	private Collider2D thisCollider;
	
	void Awake () {
		thisCollider = GetComponent<Collider2D>();
	}
	
	void OnTriggerStay2D (Collider2D other) {
		
		Drag draggableObject = other.GetComponent<Drag>();
		if (draggableObject != null) 
		{
			if(other.bounds.min.x > thisCollider.bounds.min.x && other.bounds.max.x < thisCollider.bounds.max.x)
			{
				// Debug.Log("Tada");
				
				draggableObject.Caught();
				other.transform.position = transform.position;
			}
		}
		
		// Debug.Log("Other min.x: " + other.bounds.min.x + " This min.x: " + thisCollider.bounds.min.x 
					// + " Other max.x: " + other.bounds.max.x + " This max.x: " + thisCollider.bounds.max.x);
	}
}
