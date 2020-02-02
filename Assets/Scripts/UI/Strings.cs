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
		{ "DATE1", "November 5th 2006" },
		{ "DAYS_REMAINING_1", "-7 days until launch-" },
		{ "DATE2", "November 6th 2006" },
		{ "DAYS_REMAINING_2", "-6 days until launch-" },
		{ "DATE3", "November 7th 2006" },
		{ "DAYS_REMAINING_3", "-5 days until launch-" },
		{ "DATE4", "November 8th 2006" },
		{ "DAYS_REMAINING_4", "-4 days until launch-" },
		{ "DATE5", "November 9th 2006" },
		{ "DAYS_REMAINING_5", "-3 days until launch-" },
		{ "DATE6", "November 10th 2006" },
		{ "DAYS_REMAINING_6", "-2 days until launch-" },
		{ "DATE7", "November 11th 2006" },
		{ "DAYS_REMAINING_7", "-Final day before launch-" },
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
