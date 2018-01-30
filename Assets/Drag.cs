using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	
	private Vector3 offset;
	private bool canDrag = true;
	
	void OnMouseDown()
	{
		// screenPoint = Camera.main.WorldToScreenPoint(transform.position);

		if (canDrag == true)
		{
			offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		}
	}
	
	void OnMouseDrag()
	{
		
		if (canDrag == true)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}
	
	public void Caught () {
		canDrag = false;
	}
}
