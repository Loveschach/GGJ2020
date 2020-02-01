using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {
	public enum LogStatus
	{
		Future,
		Undiscovered,
		Assigned,
		InProgress,
		Fixed,
		NotFixed
	}
	public bool logged = false;
	public LogStatus status = LogStatus.Future;
	public int buildIntroduced = 0; // one build per day
	public int ID;

	//Highlight variables
	Material material;
	public float highlightThickness = 0.1f;
	public Color highlightColor = Color.yellow;
	public Color loggedColor = Color.red;

	// Start is called before the first frame update
	void Start() {
		logged = SaveSystem.GetLogged( ID );

		Renderer renderer = GetComponent<Renderer>();
		if (renderer != null) {
			material = renderer.material;
		}
	}

	public void SetLogged( bool logged ) {
		this.logged = logged;
		material.SetColor( "_OutlineColor", loggedColor );
		material.SetFloat( "_OutlineExtrusion", highlightThickness );
	}

	public void SetHighlight() {
		if ( !logged ) {
			material.SetColor( "_OutlineColor", highlightColor );
		}
		material.SetFloat( "_OutlineExtrusion", highlightThickness );
	}

	public void ClearHighlight() {
		if ( !logged ) {
			material.SetFloat( "_OutlineExtrusion", 0 );
		}
	}
}
