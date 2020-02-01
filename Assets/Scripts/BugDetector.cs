using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDetector : MonoBehaviour
{
	[SerializeField]
	Shader bugShader; // Make sure object has this material before trying to operate on it
	Transform camTrans;

	// Used to unhighlight when we're not pointing at it anymore
	Bug lastBug;

	void Start()
	{
		camTrans = Camera.main.transform;
	}

	void ClearLastHighlight()
	{
		if (lastBug != null)
		{
			lastBug.ClearHighlight();
			lastBug = null;
		}
	}

	void Update() 
	{
		RaycastHit hit;
		//Debug.DrawRay(camTrans.position, camTrans.TransformDirection(Vector3.forward) * 100, Color.yellow);
		// Does the ray intersect any buggable objects?
		if (Physics.Raycast(camTrans.position, camTrans.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
			Bug bug = hit.collider.GetComponent<Bug>();
			if (bug != null && !bug.logged)
			{
				// If it's different, unhighlight the last thing, and highlight this thing
				if (lastBug != bug)
				{
					ClearLastHighlight();
					bug.SetHighlight();
					lastBug = bug;
				}
				if (Input.GetButtonDown("Fire1")) {
					bug.SetLogged(true);
				}
			}
			else
			{
				ClearLastHighlight();
			}
		}
		else
		{
			ClearLastHighlight();
		}
	}
}
