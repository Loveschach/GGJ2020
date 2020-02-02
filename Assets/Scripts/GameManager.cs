using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	static int MAX_DAYS = 5;
	static int SPLASH_TIMER = 1;
	static int TUTORIAL_MESSAGE_DURATION = 1;
	public static int CurrentDay = 1;
	enum GameState {
		DAY_SPLASH,
		TUTORIAL,
		TESTING,
		EVAL,
		FINAL,
	};
	GameState currentState;
	float currentTime;
	public GameObject splashScreen;
	List<string[]> tutorialText = new List<string[]>();
	float tutorialTimer = 0;
	public Canvas canvas;
	ChatBox chatBox;


	// Start is called before the first frame update
	void Start()
    {
		EnterState( GameState.DAY_SPLASH );
		string[] day1TutorialStrings = { "TUTORIAL_1a", "TUTORIAL_1b" };
		tutorialText.Add( day1TutorialStrings );
		string[] day2TutorialStrings = { "TUTORIAL_2a" };
		tutorialText.Add( day2TutorialStrings );
		string[] day3TutorialStrings = { "TUTORIAL_3a" };
		tutorialText.Add( day3TutorialStrings );
		string[] day4TutorialStrings = { "TUTORIAL_4a" };
		tutorialText.Add( day4TutorialStrings );
		string[] day5TutorialStrings = { "TUTORIAL_5a" };
		tutorialText.Add( day5TutorialStrings );
		chatBox = canvas.GetComponent<ChatBox>();
	}

	void UpdateSplashState() {
		if( currentTime >= SPLASH_TIMER ) {
			EnterState( GameState.TUTORIAL );
			Animator splashAnimator = splashScreen.GetComponent<Animator>();
			splashAnimator.SetTrigger( "Fade" );
		}
	}

	void UpdateTutorial() {
		if( currentTime >= tutorialTimer ) {
			EnterState( GameState.TESTING );
		}
	}

	void EnterSplash() {
		splashScreen.SetActive( true );
		GameObject currentDate = GameObject.Find( "Date" );
		GameObject daysRemaining = GameObject.Find( "DaysRemaining" );
		currentDate.GetComponentInChildren<Text>().text = Strings.GetString( "DATE" + CurrentDay );
		daysRemaining.GetComponentInChildren<Text>().text = Strings.GetString( "DAYS_REMAINING_" + CurrentDay );
	}

	void EnterTutorial() {
		string[] tutorialStrings = tutorialText[CurrentDay - 1];
		tutorialTimer = 0;
		foreach( string tutorial in tutorialStrings ) {
			chatBox.QueueText( Strings.GetString( tutorial ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
			tutorialTimer += TUTORIAL_MESSAGE_DURATION;
		}
	}

	void EnterState( GameState newState ) {
		switch( newState ) {
			case ( GameState.DAY_SPLASH ):
				EnterSplash();
				break;
			case ( GameState.TUTORIAL ):
				EnterTutorial();
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
			case ( GameState.TUTORIAL ):
				UpdateTutorial();
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
