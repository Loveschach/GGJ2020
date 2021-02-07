using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Strings {
	public static Dictionary<string, string> GameStrings = new Dictionary<string, string>()
	{
		{ "TEST", "Devin." },
		{ "TEST1", "You are a cool guy." },
		{ "TEST2", "Amanda is cool too, and Josh, and Nathan." },
		{ "QA_LEAD_NAME", "Adrian J." },
		{ "QA_LEAD_TITLE", "QA Lead (Your Boss)" },
		{ "DESIGNER_NAME", "xXbsp_mstrXx" },
		{ "DESIGNER_TITLE", "Level Designer" },
		{ "ENGINEER_NAME", "CodeNinja" },
		{ "ENGINEER_TITLE", "Gameplay Engineer" },
		{ "ARTIST_NAME", "drawMe1ofUrFrnchGrlz" },
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
		{ "TUTORIAL_1i", "Everyone leaves at 18:00, so you have til then each day to fix bugs. Talk to you later!" },
		{ "TUTORIAL_2a", "Day #2 time to get started!" },
		{ "TUTORIAL_2b", "How was your first day? I think the game is less buggy now, but it's hard to tell with all the churn" },
		{ "TUTORIAL_2c", "The environment artists are working on texturing, it looks great so far!" },
		{ "TUTORIAL_2d", "We can judge them for being slow, but we don't need to log the orange walls as bugs." },
		{ "TUTORIAL_2e", "Good luck today. I have a meeting today with the big boss, I hope it goes well oTL" },
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
		{ "MANAGER_fixBug_Blocked", "Oh no! We're totally blocked from testing today :[. You might as well clock out, hopefully it'll be fixed tomorrow." },
		{ "MANAGER_fixBug_Start", "Heh heh, I put that bug there! You always have to force the player to turn around at the beginning of a level :p." },
		{ "ART_fixBug_generic", "oh daaaang dude! i didnt even notice that bug earlier. i gotchu tho, fix comin' in hot!" },
		{ "ART_fixBug_generic2", "LOL omg that thing looks SO DUMB hahahahahaha. i'll change it (after i take a screenshot) xD" },
		{ "ART_fixBug_badTexture", "tbh i like the texture better that way, but i guess i gotta please the big guys lol. fixing!" },
		{ "ART_fixBug_generic3", "woah woah howd it get there????? all good, ill fix it." },
		{ "ART_fixBug_generic4", "i mean reaaaaaaaally... is it so bad?? jk good catch, that def needs to be fixed." },
		{ "ART_fixBug_generic5", "heeeey that's my little hidden buddy. i guessss ill remove it" },
		{ "ART_fixBug_generic6", "i like that one! sad to see it go :(" },
		{ "ART_fixBug_badCollision", "hah, no collision = shortcut, right? could be an easter egg. but, i guess that wouldnt be so fun. ill fix it." },
		{ "ART_fixBug_doNotUseTexture", "i guess they knew what they were doing when they told us to use do not use textures. ive got it!" },
		{ "DESIGN_fixBug_generic", "UGH why is that bug happening NOW? I bet JOHN overwrote my change. Its fine, I'll fix HIS mistake." },
		{ "DESIGN_fixBug_entSpeed", "I TOLD John that those entities were moving oddly! He NEVER listens to me. Now I gotta fix it." },
		{ "DESIGN_fixBug_unbeatable", "MAN, not being able to beat the level IS a problem. How could JOHN have overlooked something so BAD like that?" },
		{ "DESIGN_fixBug_killerGeo", "I bet JOHN accidentally clicked on the WRONG thing when he made this thing DEADLY to the player. I'll correct it." },
		{ "DESIGN_fixBug_invisCollision", "Oh my god. Did John REALLY delete that old geo without deleting the collision too? ROOKIE mistake. I'll fix it." },
		{ "DESIGN_fixBug_clipLevel", "Dog-GONNIT John overwrote my changes and now the player CLIPS through the level. I'll have to fix those changes." },
		{ "CODE_fixBug_generic", "Fixing that feature was scheduled for next week. Whatever, I guess I'll stay late (again) and look into it." },
		{ "CODE_fixBug_plyrInvincible", "The enemies aren't harming the player? Are you sure this isn't a designer/scripter issue where they forgot to add it to the enemy stats? Whatever, I'll look at it." },
		{ "CODE_fixBug_enemyOverload_a", "Crashing from too many enemies? I'll waste my time raising the allowable memory for now, but really art needs to make lower res enemies to cut down on costs." },
		{ "CODE_fixBug_enemyOverload_b", "They never think about that." },
		{ "CODE_fixBug_runtimeError_a", "I really don't have time for this. Is there no way around this?" },
		{ "CODE_fixBug_runtimeError_b", "Hello? No? You know, this is the reason why I'm forced to work 14 hours a day. *sigh*" },
		{ "CODE_fixBug_plyrSpeed_a", "I really don't think the player speed is an issue. So I'm not sure why this is being bugged." },
		{ "CODE_fixBug_plyrSpeed_b", "Design just came complaining to me about it so I guess I'll stay late to fix this. They're always so dramatic." },
		{ "CODE_fixBug_badPowerup", "Do we even have powerups in this game? Fine. I'll make it so it does... something." },
		{ "CODE_badCollision1", "Fixing that feature was scheduled for next week. Whatever, I guess I'll stay late (again) and look into it" },
		{ "CODE_badCollision2", "Are you sure this isn't a designer/scripter issue where they forgot to add it collision? Whatever, I'll look at it QA slime." },
		{ "QA_wrongBug_generic", "Uhhhh hey, just letting you know that we've gotten a complaint. Try to be a bit more observant for this build, and be careful about what you bug up! :E" },
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
