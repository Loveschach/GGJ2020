﻿using System.Collections;
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
	public string completionStringKey;
	public string failedStringKey;
	public ChatBox.Chatters chatter;

	//Highlight variables
	Material material;
	public float highlightThickness = 0.1f;
	public Color highlightColor = Color.yellow;
	public Color loggedColor = Color.red;

	//For updating the fix/log state
	[SerializeField] private GameObject m_broken;
	[SerializeField] private GameObject m_fixed;

	// Start is called before the first frame update
	void Start() {
		Renderer renderer = GetComponent<Renderer>();
		if (renderer != null) {
			material = renderer.material;
		}

		logged = SaveSystem.GetLogged( ID );
		UpdateFixState();
	}

	void UpdateFixState() {
		if (!m_fixed || !m_broken) {
			Debug.LogWarning("Broken and/or Fixed states are null. Bug cannot be logged.");
			return;
		}
		
		if (logged) {
			m_fixed.SetActive(true);
			m_broken.SetActive(false);
		}
		else {
			m_fixed.SetActive(false);
			m_broken.SetActive(true);
		}
	}

	public void SetLogged( bool logged ) {
		this.logged = logged;
		material.SetColor( "_OutlineColor", loggedColor );
		material.SetFloat( "_OutlineExtrusion", highlightThickness );
		material.SetFloat("_Alpha", 1);

		//Save logged state for next day
		SaveSystem.Save();
	}

	public void SetHighlight() {
		if ( !logged ) {
			material.SetColor( "_OutlineColor", highlightColor );
			material.SetFloat( "_OutlineExtrusion", highlightThickness );
			material.SetFloat("_Alpha", 1);
		}
	}

	public void ClearHighlight() {
		if ( !logged ) {
			material.SetFloat( "_OutlineExtrusion", 0 );
			material.SetFloat("_Alpha", 0);
		}
	}
}
