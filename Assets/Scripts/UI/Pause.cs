using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	public GameObject pauseScreen;
	PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
		pauseMenu = pauseScreen.GetComponent<PauseMenu>();   
    }

    // Update is called once per frame
    void Update()
    {
		if ( Input.GetButtonDown( "Cancel" ) ) {
			if ( pauseScreen.activeSelf ) {
				pauseMenu.Resume();
			}
			else {
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				pauseScreen.SetActive( true );
			}
		}
	}
}
