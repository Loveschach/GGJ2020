using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static int MAX_DAYS = 5;
	static int SPLASH_TIMER = 3;
	static int TUTORIAL_MESSAGE_DURATION = 4;
	static int LEVEL_TIME = 140;
	static int LEVEL_START_TIME = 8;
	static int LEVEL_END_TIME = 18;
	public static int CurrentDay = 1;
	public enum GameState {
		DAY_SPLASH,
		TUTORIAL,
		TESTING,
		NEXT,
	};
	public static GameState CurrentState;
	static float currentTime;
	public GameObject splashScreen;
	public bool playSplash = true;
	public bool playTutorial = true;
	List<string[]> tutorialText = new List<string[]>();
	float tutorialTimer = 0;


	// Start is called before the first frame update
	void Start()
    {
		currentTime = 0;
		EnterState( GameState.DAY_SPLASH );
		string[] day1TutorialStrings = { "TUTORIAL_1a", "TUTORIAL_1b", "TUTORIAL_1c", "TUTORIAL_1d", "TUTORIAL_1e", "TUTORIAL_1g", "TUTORIAL_1h", "TUTORIAL_1i" };
		tutorialText.Add( day1TutorialStrings );
		string[] day2TutorialStrings = { "TUTORIAL_2a", "TUTORIAL_2b", "TUTORIAL_2c", "TUTORIAL_2d", "TUTORIAL_2e" };
		tutorialText.Add( day2TutorialStrings );
		string[] day3TutorialStrings = { "TUTORIAL_3a", "TUTORIAL_3b", "TUTORIAL_3c", "TUTORIAL_3d" };
		tutorialText.Add( day3TutorialStrings );
		string[] day4TutorialStrings = { "TUTORIAL_4a", "TUTORIAL_4b", "TUTORIAL_4c" };
		tutorialText.Add( day4TutorialStrings );
		string[] day5TutorialStrings = { "TUTORIAL_5a", "TUTORIAL_5b", "TUTORIAL_5c", "TUTORIAL_5d" };
		tutorialText.Add( day5TutorialStrings );
	}

	public static string GetTime() {
		if ( CurrentState == GameState.DAY_SPLASH || CurrentState == GameState.TUTORIAL ) {
			return LEVEL_START_TIME.ToString( "00" ) + ":00";
		} else {
			float percentDone = currentTime / LEVEL_TIME;
			float timeProgress = ( LEVEL_END_TIME - LEVEL_START_TIME ) * percentDone;
			string hour = "" + ( Mathf.Floor( timeProgress ) + LEVEL_START_TIME ).ToString( "00" );
			float minutePercent = timeProgress - Mathf.Floor( timeProgress );
			string minute = "" + Mathf.Floor( minutePercent * 60 ).ToString( "00" );
			return hour + ":" + minute;
		}
	}

	void UpdateSplashState() {
		if ( !playSplash ) {
			EnterState( GameState.TUTORIAL );
		}
		else if( currentTime >= SPLASH_TIMER ) {
			EnterState( GameState.TUTORIAL );
			Animator splashAnimator = splashScreen.GetComponent<Animator>();
			splashAnimator.SetTrigger( "Fade" );
		}
	}

	void UpdateTutorial() {
		if( !playTutorial || currentTime >= tutorialTimer ) {
			EnterState( GameState.TESTING );
		}
	}

	void UpdateTesting() {
		float percentDone = currentTime / LEVEL_TIME;
		float timeProgress = ( LEVEL_END_TIME - LEVEL_START_TIME ) * percentDone;
		float hour = ( Mathf.Floor( timeProgress ) + LEVEL_START_TIME );
		if ( hour >= LEVEL_END_TIME ) {
			EnterState( GameState.NEXT );
		}
	}

	void EnterSplash() {
		if ( playSplash )
		{
			currentTime = 0;
			tutorialTimer = 0;
			splashScreen.SetActive( true );
			GameObject currentDate = GameObject.Find( "Date" );
			GameObject daysRemaining = GameObject.Find( "DaysRemaining" );
			currentDate.GetComponentInChildren<Text>().text = Strings.GetString( "DATE" + CurrentDay );
			daysRemaining.GetComponentInChildren<Text>().text = Strings.GetString( "DAYS_REMAINING_" + CurrentDay );
		}
		
	}

	void EnterTutorial() {
		if ( playTutorial )
		{
			string[] tutorialStrings = tutorialText[CurrentDay - 1];
			tutorialTimer = 0;
			foreach( string tutorial in tutorialStrings ) {
				ChatBox.QueueText( Strings.GetString( tutorial ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
				tutorialTimer += TUTORIAL_MESSAGE_DURATION;
			}
		}
		
	}

	static void EnterNext() {
		CurrentDay += 1;
		ChatBox.ClearQueue();
		SaveSystem.Save();
		SceneManager.LoadScene( CurrentDay );
	}

	public static void EndLevel() {
		EnterNext();
	}

	void EnterTesting() {
		currentTime = 0;
	}

	void EnterState( GameState newState ) {
		switch( newState ) {
			case ( GameState.DAY_SPLASH ):
				EnterSplash();
				break;
			case ( GameState.TUTORIAL ):
				EnterTutorial();
				break;
			case ( GameState.TESTING ):
				EnterTesting();
				break;
			case ( GameState.NEXT ):
				EnterNext();
				break;
			default:
				break;
		}
		CurrentState = newState;
	}

	void UpdateState() {
		switch ( CurrentState ) {
			case ( GameState.DAY_SPLASH ):
				UpdateSplashState();
				break;
			case ( GameState.TUTORIAL ):
				UpdateTutorial();
				break;
			case ( GameState.TESTING ):
				UpdateTesting();
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
