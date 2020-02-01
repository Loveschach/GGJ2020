using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDetector : MonoBehaviour
{
	[SerializeField]
	Shader bugShader; // Make sure object has this material before trying to operate on it
	[SerializeField]
	float highlightThickness = 0.1f;
	Transform camTrans;

	// Used to unhighlight when we're not pointing at it anymore
	Renderer lastRenderer;

	void Start()
	{
		camTrans = Camera.main.transform;
	}

	void ClearLastHighlight()
	{
		if (lastRenderer != null)
		{
			lastRenderer.material.SetFloat("_OutlineExtrusion", 0);
			lastRenderer = null;
		}
	}

	void FixedUpdate() 
	{
		RaycastHit hit;
		//Debug.DrawRay(camTrans.position, camTrans.TransformDirection(Vector3.forward) * 100, Color.yellow);
		// Does the ray intersect any buggable objects?
		if (Physics.Raycast(camTrans.position, camTrans.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
			Renderer otherRenderer = hit.collider.gameObject.GetComponent<Renderer>();
			if (otherRenderer != null && otherRenderer.material.shader == bugShader)
			{
				// If it's different, unhighlight the last thing, and highlight this thing
				if (lastRenderer != otherRenderer)
				{
					ClearLastHighlight();
					otherRenderer.material.SetFloat("_OutlineExtrusion", highlightThickness);
					lastRenderer = otherRenderer;
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
