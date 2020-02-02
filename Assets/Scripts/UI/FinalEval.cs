using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalEval : MonoBehaviour
{
	static int SPLASH_1_TIME = 3;
	static int SPLASH_2_TIME = 9;
	static int SPLASH_3_TIME = 3;
	static int PRE_EXIT_TIME = 3;
	static string EPILOGUE_BAD = "Critics hate your game.\nIt's basically unplayable because of bugs.\nAdrian J. was fired.\nxXbsp_mstrXx died.\ndrawMe1ofUrFrnchGrlz broke their pencil.\nCodeNinja got a pay raise.";
	static string META_BAD = "79%";
	static string EPILOGUE_OK = "Critics think your game is just fine.\nThere are bugs, but not too many.\nAdrian J. stayed at their job for 20 years.\nxXbsp_mstrXx's level was mentioned in 5 reviews.\ndrawMe1ofUrFrnchGrlz got 1000 new UsTube followers.\nCodeNinja ate some rotten turkey.";
	static string META_OK = "81%";
	static string EPILOGUE_GOOD = "Your game is the biggest thing since GYE V!\nNobody ran into any bugs ever.\nAdrian J. quit their job and started a succesful indie studio.\nxXbsp_mstrXx and drawMe1ofUrFrnchGrlz got married.\nCodeNinja took a sabbatical in Spain and was never seen again.";
	static string META_GOOD = "95%";
	public GameObject splash1;
	public GameObject splash2;
	public GameObject splash3;
	public GameObject final;
	public GameObject exitButton;
	int totalResolvedBugs;
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
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		splash1.SetActive( true );
		splash2.SetActive( false );
		splash3.SetActive( false );
		exitButton.SetActive( false );
		final.SetActive( false );
		Evaluate();

		Text metaText = final.transform.Find( "Rating" ).GetComponent<Text>();
		if ( totalResolvedBugs >= 20 ) {
			metaText.text = META_GOOD;
		}
		else if ( totalResolvedBugs >= 10 ) {
			metaText.text = META_OK;
		}
		else {
			metaText.text = META_BAD;
		}

		Text splash2Text = splash2.transform.Find( "Epilogue" ).GetComponent<Text>();
		if ( totalResolvedBugs >= 20 ) {
			splash2Text.text = EPILOGUE_GOOD;
		}
		else if ( totalResolvedBugs >= 10 ) {
			splash2Text.text = EPILOGUE_OK;
		} 
		else {
			splash2Text.text = EPILOGUE_BAD;
		}
	}

	void Evaluate() {
		totalResolvedBugs = 0;
		for ( int bugID = 0; bugID < SaveSystem.MAX_BUGS; bugID++ ) {
			totalResolvedBugs += PlayerPrefs.GetInt( SaveSystem.BUG_SAVE + bugID, 0 );
		}
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
