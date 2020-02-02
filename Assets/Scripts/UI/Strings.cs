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
		{ "DATE1", "November 6th 2006" },
		{ "DAYS_REMAINING_1", "-5 days until launch-" },
		{ "DATE2", "November 7th 2006" },
		{ "DAYS_REMAINING_2", "-4 days until launch-" },
		{ "DATE3", "November 8th 2006" },
		{ "DAYS_REMAINING_3", "-3 days until launch-" },
		{ "DATE4", "November 9th 2006" },
		{ "DAYS_REMAINING_4", "-2 days until launch-" },
		{ "DATE5", "November 10th 2006" },
		{ "DAYS_REMAINING_5", "-Final day before launch-" },
		{ "TUTORIAL_1a", "Hey Rookie, welcome to Games Corp!" },
		{ "TUTORIAL_1b", "Are you excited to be working on Haunted Hijinx 2: Remastered? At the studio we all call it HH2R" },
		{ "TUTORIAL_1c", "It's an exciting time to be starting! We're launching the game in 5 days :O" },
		{ "TUTORIAL_1d", "As you know, your job is QA. I need you to play through this level and find as many bugs as you can so the devs can fix them." },
		{ "TUTORIAL_1e", "We set up some QA specific controls in HH2R. Just hold the right mouse button and click on any bugs you see. The devs will see your report and fix it." },
		{ "TUTORIAL_1f", "Don't log anything that isn't a bug though, the devs will freak out and report you to the Studio head >:[" },
		{ "TUTORIAL_1g", "Our JudgeyGame scores is totally dependent on how bug free the game is. Management says if we get less than 80% they'll shut down the studio :E" },
		{ "TUTORIAL_1h", "Anyways, sorry to talk your ear off. Don't worry too much about it, just do your job well and you won't get fired." },
		{ "TUTORIAL_1i", "Everyone leaves at 20:00, so you have til then each day to fix bugs. Talk to you later!" },
		{ "TUTORIAL_2a", "Day #2 time to get started!" },
		{ "TUTORIAL_2b", "How was your first day? I think the game is less buggy now, but it's hard to tell with all the churn" },
		{ "TUTORIAL_2c", ":3 :3 :3 :3 :3" },
		{ "TUTORIAL_2d", ":3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3 :3" },
		{ "TUTORIAL_2e", "Uhh, yea. Good luck. I have a meeting today with the big boss, I hope it goes well OTL" },
		{ "TUTORIAL_3a", "Day 3, nice :->" },
		{ "TUTORIAL_3b", "Boss man screamed at me for like 2 hours. He says the investors are concerned HH2R is going to underperform." },
		{ "TUTORIAL_3c", "He says we're not hitting our quotas, but don't worry they don't know any QA's name so I can take the blame." },
		{ "TUTORIAL_3d", "Juuuust try to find a lot of bugs today, okay?" },
		{ "TUTORIAL_4a", "I'm not sure if I'll have my job here for much longer." },
		{ "TUTORIAL_4b", "Don't worry, I'm sure your new lead will be super nice and better than me at management" },
		{ "TUTORIAL_4c", "Try not to forget me when you become a game dev superstar, yea?" },
		{ "TUTORIAL_5a", "Hey Dude!" },
		{ "TUTORIAL_5b", "Sorry about the doom and gloom yesterday, I thought they were going to fire me, but they gave me a raise :OOOOOOOO" },
		{ "TUTORIAL_5c", "Although, yesterday got me thinking about what would happen if I did leave, and it sounds kind of nice..." },
		{ "TUTORIAL_5d", "Nevermind that, we have a game to ship! Good luck today it's the final push, GIVE IT YOUR ALL o7" },
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
