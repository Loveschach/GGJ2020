using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {

	public bool logged = false;
	public int ID;
	public string[] CompletionStrings;
	public string failedStringKey;
	public ChatBox.Chatters chatter;

	//Highlight variables
	public Shader[] supportedOutlineShaders;
	List<Material> materials;
	public float highlightThickness = 0.1f;
	public Color highlightColor = Color.yellow;
	public Color loggedColor = Color.red;

	//For updating the fix/log state
	[SerializeField] private GameObject m_broken;
	[SerializeField] private GameObject m_fixed;

	// Start is called before the first frame update
	void Start() {
		materials = new List<Material>();

		//Get materials that can highlight
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers) {
			foreach (Material material in renderer.materials) {
				foreach (Shader shader in supportedOutlineShaders) {
					if (material.shader == shader) {
						materials.Add(material);
					}
				}
			}
		}
		//materials = GetComponentsInChildren<Material>();

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
		foreach (Material material in materials) {
			material.SetColor("_OutlineColor", loggedColor);
			material.SetFloat("_OutlineExtrusion", highlightThickness);
			material.SetFloat("_Alpha", 1);
		}

		if( logged ) {
			ChatBox.QueueTexts( CompletionStrings, 3, chatter );
		}
		//Save logged state for next day
		SaveSystem.Save();
	}

	public void SetHighlight() {
		if ( !logged ) {
			foreach (Material material in materials) {
				material.SetColor("_OutlineColor", highlightColor);
				material.SetFloat("_OutlineExtrusion", highlightThickness);
				material.SetFloat("_Alpha", 1);
			}
		}
	}

	public void ClearHighlight() {
		if ( !logged ) {
			foreach (Material material in materials) {
				material.SetFloat("_OutlineExtrusion", 0);
				material.SetFloat("_Alpha", 0);
			}
		}
	}
}
