using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	static int MAX_DAYS = 7;
	static int SPLASH_TIMER = 1;
	public static int CurrentDay = 4;
	enum GameState {
		DAY_SPLASH,
		TESTING,
		EVAL,
		FINAL,
	};
	GameState currentState;
	float currentTime;
	public GameObject splashScreen;


	// Start is called before the first frame update
	void Start()
    {
		EnterState( GameState.DAY_SPLASH );
    }

	void UpdateSplashState() {
		if( currentTime >= SPLASH_TIMER ) {
			EnterState( GameState.TESTING );
			Animator splashAnimator = splashScreen.GetComponent<Animator>();
			splashAnimator.SetTrigger( "Fade" );
		}
	}

	void EnterSplash() {
		currentState = GameState.DAY_SPLASH;
		splashScreen.SetActive( true );
		GameObject currentDate = GameObject.Find( "Date" );
		GameObject daysRemaining = GameObject.Find( "DaysRemaining" );
		currentDate.GetComponentInChildren<Text>().text = Strings.GetString( "DATE" + CurrentDay );
		daysRemaining.GetComponentInChildren<Text>().text = Strings.GetString( "DAYS_REMAINING_" + CurrentDay );
	}

	void EnterState( GameState newState ) {
		switch( newState ) {
			case ( GameState.DAY_SPLASH ):
				EnterSplash();
				break;
			default:
				break;
		}
		currentState = newState;
	}

	void UpdateState() {
		switch ( currentState ) {
			case ( GameState.DAY_SPLASH ):
				UpdateSplashState();
				break;
			default:
				break;
		}
		currentTime += Time.deltaTime;
	}

    // Update is called once per frame
    void Update()
    {
		UpdateState();
    }

	public static void IncrementDay() {
		Debug.Assert( CurrentDay < MAX_DAYS );
		CurrentDay++;
	}
}
