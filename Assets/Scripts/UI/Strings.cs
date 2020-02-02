using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Strings {
	public static Dictionary<string, string> GameStrings = new Dictionary<string, string>()
	{
		{ "TEST", "Devin." },
		{ "TEST1", "You are a cool guy." },
		{ "TEST2", "Amanda is cool too, and Josh, and Nathan." },
		{ "QA_LEAD_NAME", "Pesticide" },
		{ "QA_LEAD_TITLE", "QA Lead (Your Boss)" },
		{ "DESIGNER_NAME", "Rock Blockster" },
		{ "DESIGNER_TITLE", "Level Designer" },
		{ "ENGINEER_NAME", "Malloculous" },
		{ "ENGINEER_TITLE", "Gameplay Engineer" },
		{ "ARTIST_NAME", "Barely Copic" },
		{ "ARTIST_TITLE", "Level Artist" },
	};

	public static string GetString( string key ) {
		string gottenString;
		GameStrings.TryGetValue( key, out gottenString );
		if( gottenString == "" ) {
			Debug.Log( "Tried to get string " + key + " but it was not found." );
		}
		return gottenString;
	}
}
