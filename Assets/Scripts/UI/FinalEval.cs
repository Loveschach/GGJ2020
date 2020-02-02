using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEval : MonoBehaviour
{
	static int SPLASH_1_TIME = 3;
	static int SPLASH_2_TIME = 5;
	static int SPLASH_3_TIME = 3;
	static int PRE_EXIT_TIME = 3;
	public GameObject splash1;
	public GameObject splash2;
	public GameObject splash3;
	public GameObject final;
	public GameObject exitButton;
	enum FinalState {
		SPLASH_1,
		SPLASH_2,
		SPLASH_3,
		PRE_EXIT,
		FINAL,
	}
	float currentTime = 0;
	FinalState currentState;

    // Start is called before the first frame update
    void Start()
    {
		splash1.SetActive( true );
		splash2.SetActive( false );
		splash3.SetActive( false );
		exitButton.SetActive( false );
		final.SetActive( false );
    }

	public void Exit() {
		Application.Quit();
	}

	void UpdateState() {
		switch ( currentState ) {
			case ( FinalState.SPLASH_1 ):
				if( currentTime >= SPLASH_1_TIME ) {
					splash1.SetActive( false );
					splash2.SetActive( true );
					currentState = FinalState.SPLASH_2;
					currentTime = 0;
				}
				break;
			case ( FinalState.SPLASH_2 ):
				if ( currentTime >= SPLASH_2_TIME ) {
					splash2.SetActive( false );
					splash3.SetActive( true );
					currentState = FinalState.SPLASH_3;
					currentTime = 0;
				}
				break;
			case ( FinalState.SPLASH_3 ):
				if ( currentTime >= SPLASH_3_TIME ) {
					splash3.SetActive( false );
					final.SetActive( true );
					currentState = FinalState.PRE_EXIT;
					currentTime = 0;
				}
				break;
			case ( FinalState.PRE_EXIT ):
				if ( currentTime >= PRE_EXIT_TIME ) {
					exitButton.SetActive( true );
					currentState = FinalState.PRE_EXIT;
					currentTime = 0;
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
