using UnityEngine;

public static class SaveSystem
{
	static string BUG_SAVE = "bug";
	static string DAY_SAVE = "day";
	static int MAX_DAYS = 7;
	static int MAX_BUGS = 100;
	static int currentDay;
	public static void Save( Bug[] bugs ) {
		foreach( Bug bug in bugs ) {
			PlayerPrefs.SetInt( BUG_SAVE + bug.ID, bug.logged == true ? 1 : 0 );
		}

		PlayerPrefs.SetInt( DAY_SAVE, currentDay );
		PlayerPrefs.Save();
	}

	public static void Delete() {
		for( int bugID = 0; bugID < MAX_BUGS; bugID++ ) {
			PlayerPrefs.SetInt( BUG_SAVE + bugID, 0 );
		}

		PlayerPrefs.SetInt( DAY_SAVE, 1 );
	}

	public static void Load() {
		currentDay = PlayerPrefs.GetInt( DAY_SAVE );
	}

	public static void IncrementDay() {
		Debug.Assert( currentDay < MAX_DAYS );
		currentDay++;
	}

	public static bool GetLogged( int bugID ) {
		return PlayerPrefs.GetInt( BUG_SAVE + bugID, 0 ) != 0;
	}
}
