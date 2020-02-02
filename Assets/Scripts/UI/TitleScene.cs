using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
	static int SPLASH_1_TIME = 3;
	static int SPLASH_2_TIME = 3;
	public GameObject splash1;
	public GameObject splash2;
	public GameObject title;
	enum TitleState {
		SPLASH_1,
		SPLASH_2,
		TITLE,
	}
	float currentTime = 0;
	TitleState currentState;

    // Start is called before the first frame update
    void Start()
    {
		splash1.SetActive( true );
		splash2.SetActive( false );
		title.SetActive( false );
    }

	public void StartButton() {
		SceneManager.LoadScene( 1 );
	}

	public void Exit() {
		Application.Quit();
	}

	void UpdateState() {
		switch ( currentState ) {
			case ( TitleState.SPLASH_1 ):
				if( currentTime >= SPLASH_1_TIME ) {
					splash1.SetActive( false );
					splash2.SetActive( true );
					currentState = TitleState.SPLASH_2;
					currentTime = 0;
				}
				break;
			case ( TitleState.SPLASH_2 ):
				if ( currentTime >= SPLASH_2_TIME ) {
					splash2.SetActive( false );
					title.SetActive( true );
					currentState = TitleState.TITLE;
				}
				break;
			default:
				break;
		}
	}

    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;
		UpdateState();
    }
}
