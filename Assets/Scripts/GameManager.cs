using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static int MAX_DAYS = 7;
	public static int CurrentDay;
	enum GameState {
		DAY_SPLASH,
		TESTING,
		EVAL,
		FINAL,
	};
	GameState currentState;

	// Start is called before the first frame update
	void Start()
    {
		currentState = GameState.DAY_SPLASH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public static void IncrementDay() {
		Debug.Assert( CurrentDay < MAX_DAYS );
		CurrentDay++;
	}
}
