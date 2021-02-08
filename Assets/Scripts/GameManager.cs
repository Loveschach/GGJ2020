using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	static int MAX_DAYS = 5;
	static int SPLASH_TIMER = 3;
	static int TUTORIAL_MESSAGE_DURATION = 4;
	public int HOUR_TIME = 14;
	static int LEVEL_START_TIME = 8;
	public int LEVEL_END_TIME = 18;
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
	public GameObject[] BugContainers;
	public static UnityEvent BugLogged = new UnityEvent();
	GameObject player;
	bool outOfBoundsPrompted = false;
	public AudioSource MusicAudio;


	// Start is called before the first frame update
	void Start()
    {
		currentTime = 0;
		player = GameObject.FindGameObjectWithTag( "Player" );
		EnterState( GameState.DAY_SPLASH );
		string[] day1TutorialStrings = { "TUTORIAL_1a", "TUTORIAL_1b", "TUTORIAL_1c", "TUTORIAL_1d", "TUTORIAL_1e", "TUTORIAL_1g" };
		tutorialText.Add( day1TutorialStrings );
		string[] day2TutorialStrings = { "TUTORIAL_2a", "TUTORIAL_2b", "TUTORIAL_2c", "TUTORIAL_2d" };
		tutorialText.Add( day2TutorialStrings );
		string[] day3TutorialStrings = { "TUTORIAL_3a", "TUTORIAL_3b", "TUTORIAL_3c" };
		tutorialText.Add( day3TutorialStrings );
		string[] day4TutorialStrings = { "TUTORIAL_4a", "TUTORIAL_4b", "TUTORIAL_4c" };
		tutorialText.Add( day4TutorialStrings );
		string[] day5TutorialStrings = { "TUTORIAL_5a", "TUTORIAL_5b", "TUTORIAL_5c", "TUTORIAL_5d" };
		tutorialText.Add( day5TutorialStrings );
		BugLogged.AddListener( EvaluateBugs );
	}

	public float GetLevelTime() {
		return ( LEVEL_END_TIME - LEVEL_START_TIME ) * HOUR_TIME;
	}

	public string GetTime() {
		if ( CurrentState == GameState.DAY_SPLASH || CurrentState == GameState.TUTORIAL ) {
			return LEVEL_START_TIME.ToString( "00" ) + ":00";
		} else {
			float levelTime = GetLevelTime();
			float percentDone = currentTime / levelTime;
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
		float levelTime = GetLevelTime();
		float percentDone = currentTime / levelTime;
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
			splashScreen.GetComponent<AudioSource>().Play();
			GameObject currentDate = GameObject.Find( "Date" );
			GameObject daysRemaining = GameObject.Find( "DaysRemaining" );
			currentDate.GetComponentInChildren<Text>().text = Strings.GetString( "DATE" + CurrentDay );
			daysRemaining.GetComponentInChildren<Text>().text = Strings.GetString( "DAYS_REMAINING_" + CurrentDay );
			player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
		}
		
	}

	void EnterTutorial() {
		if ( playTutorial )
		{
			if( CurrentDay > 3 ) {
				MusicAudio.Play();
			}

			player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			string[] tutorialStrings = tutorialText[CurrentDay - 1];
			tutorialTimer = 0;
			foreach( string tutorial in tutorialStrings ) {
				ChatBox.QueueText( Strings.GetString( tutorial ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
				tutorialTimer += TUTORIAL_MESSAGE_DURATION;
			}
		}
		
	}

	bool AllBugsLogged() {
		if( BugContainers.Length == 0 ) {
			return false;
		}

		foreach ( GameObject bugContainer in BugContainers ) {
			Bug[] bugs = bugContainer.GetComponentsInChildren<Bug>();

			foreach ( Bug bug in bugs ) {
				if ( !bug.logged ) {
					return false;
				}
			}
		}
		return true;
	}

	void EvaluateBugs() {
		if( AllBugsLogged() ) {
			if ( CurrentDay == MAX_DAYS ) {
				ChatBox.QueueText( Strings.GetString( "MANAGER_foundAllBugsFinal" ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
				ChatBox.QueueText( Strings.GetString( "MANAGER_foundAllBugsFinal2" ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
				ChatBox.QueueText( Strings.GetString( "MANAGER_foundAllBugsFinal3" ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
			} else {
				ChatBox.QueueText( Strings.GetString( "MANAGER_foundAllBugs" ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
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
		if( player.transform.position.y <= -8 && !outOfBoundsPrompted ) {
			ChatBox.QueueText( Strings.GetString( "MANAGER_outOfBounds" ), TUTORIAL_MESSAGE_DURATION, ChatBox.Chatters.QA_LEAD );
			outOfBoundsPrompted = true;
		}
    }

	public static void IncrementDay() {
		Debug.Assert( CurrentDay < MAX_DAYS );
		CurrentDay++;
	}
}
