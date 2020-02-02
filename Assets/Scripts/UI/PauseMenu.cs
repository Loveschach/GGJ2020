using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void Resume() {
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		gameObject.SetActive( false );
	}

	public void EndLevel() {
		GameManager.EndLevel();
		Resume();
	}

	public void Exit() {
		Application.Quit();
	}

	// Update is called once per frame
	void Update() {
	}
}
