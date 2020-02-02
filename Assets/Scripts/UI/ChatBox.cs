using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChatBox : MonoBehaviour
{
	public enum Chatters {
		QA_LEAD,
		DESIGNER,
		ENGINEER,
		ARTIST,
		SIZE = ARTIST + 1,
	};

	struct ChatterData {
		public string name;
		public string title;
		public Sprite pic;
	}
	ChatterData[] chatterData = new ChatterData[(int)Chatters.SIZE];

	public Sprite[] ProfilePics;

    // Start is called before the first frame update
    void Start()
    {
		chatterData[( int )Chatters.QA_LEAD].name = Strings.GetString( "QA_LEAD_NAME" );
		chatterData[( int )Chatters.QA_LEAD].title = Strings.GetString( "QA_LEAD_TITLE" );
		chatterData[( int )Chatters.QA_LEAD].pic = ProfilePics[( int )Chatters.QA_LEAD];

		chatterData[( int )Chatters.DESIGNER].name = Strings.GetString( "DESIGNER_NAME" );
		chatterData[( int )Chatters.DESIGNER].title = Strings.GetString( "DESIGNER_TITLE" );
		chatterData[( int )Chatters.DESIGNER].pic = ProfilePics[( int )Chatters.DESIGNER];

		chatterData[( int )Chatters.ENGINEER].name = Strings.GetString( "ENGINEER_NAME" );
		chatterData[( int )Chatters.ENGINEER].title = Strings.GetString( "ENGINEER_TITLE" );
		chatterData[( int )Chatters.ENGINEER].pic = ProfilePics[( int )Chatters.ENGINEER];

		chatterData[( int )Chatters.ARTIST].name = Strings.GetString( "ARTIST_NAME" );
		chatterData[( int )Chatters.ARTIST].title = Strings.GetString( "ARTIST_TITLE" );
		chatterData[( int )Chatters.ARTIST].pic = ProfilePics[( int )Chatters.ARTIST];
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
