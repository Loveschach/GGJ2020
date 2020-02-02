using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public GameObject dummyChatObject;
	public Image profilePic;
	public Text chatterName;
	public Text chatterTitle;
	public GameObject chatPanel;

	public Sprite[] ProfilePics;

	struct ChatMessage {
		public int duration;
		public Chatters chatter;
		public string text;
	}
	Queue<ChatMessage> chatQueue = new Queue<ChatMessage>();
	List<GameObject> chatObjects = new List<GameObject>();
	float currentTime = -1;

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
		QueueText( Strings.GetString( "TEST" ), 3, Chatters.QA_LEAD );
		QueueText( Strings.GetString( "TEST1" ), 3, Chatters.DESIGNER );
		QueueText( Strings.GetString( "TEST2" ), 3, Chatters.ENGINEER );
	}

	public void QueueText( string text, int duration, Chatters chatter ) {
		ChatMessage message = new ChatMessage();
		message.text = text;
		message.duration = duration;
		message.chatter = chatter;
		chatQueue.Enqueue( message );
	}

	void MoveChatsUpAndKill( float moveUpAmount ) {
		GameObject objectToRemove = null;
		foreach( GameObject chatObject in chatObjects ) {
			chatObject.transform.position = new Vector3( chatObject.transform.position.x, chatObject.transform.position.y + moveUpAmount, chatObject.transform.position.z );
			RectTransform rect = chatObject.GetComponent<RectTransform>();
			if ( rect.position.y > 1080 ) {
				objectToRemove = chatObject;
			}
		}

		chatObjects.Remove( objectToRemove );
		Destroy( objectToRemove );
	}

	void PlayMessage( ChatMessage message ) {
		GameObject newChat = Instantiate( dummyChatObject, chatPanel.transform );
		newChat.SetActive( true );

		Text text = newChat.GetComponentInChildren<Text>();
		text.text = message.text;

		ChatterData data = chatterData[(int)message.chatter];
		profilePic.sprite = data.pic;
		chatterTitle.text = data.title;
		chatterName.text = data.name;

		RectTransform rect = newChat.GetComponent<RectTransform>();
		MoveChatsUpAndKill( rect.rect.height );
		chatObjects.Add( newChat );
	}

    // Update is called once per frame
    void Update()
    {
        if( chatQueue.Count > 0 ) {
			if ( chatQueue.Count > 1 && currentTime >= chatQueue.Peek().duration ) {
				currentTime = 0;
				chatQueue.Dequeue();
				PlayMessage( chatQueue.Peek() );
			} else if ( currentTime == -1 ) {
				currentTime = 0;
				PlayMessage( chatQueue.Peek() );
			}
		}

		currentTime += Time.deltaTime;
    }
}
