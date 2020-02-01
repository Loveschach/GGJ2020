using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	static string BUG_SAVE = "bug";
	static string DAY_SAVE = "day";
	static int MAX_BUGS = 100;
	public static void Save() {
		Bug[] bugs = FindObjectsOfType<Bug>();
		foreach( Bug bug in bugs ) {
			PlayerPrefs.SetInt( BUG_SAVE + bug.ID, bug.logged == true ? 1 : 0 );
		}

		PlayerPrefs.SetInt( DAY_SAVE, GameManager.CurrentDay );
		PlayerPrefs.Save();
	}

	public static void Delete() {
		for( int bugID = 0; bugID < MAX_BUGS; bugID++ ) {
			PlayerPrefs.SetInt( BUG_SAVE + bugID, 0 );
		}

		PlayerPrefs.SetInt( DAY_SAVE, 1 );
	}

	public static void Load() {
		GameManager.CurrentDay = PlayerPrefs.GetInt( DAY_SAVE );
	}

	public static bool GetLogged( int bugID ) {
		return PlayerPrefs.GetInt( BUG_SAVE + bugID, 0 ) != 0;
	}
}
