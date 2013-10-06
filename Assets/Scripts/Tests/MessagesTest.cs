using UnityEngine;
using System.Collections;
using PoliticsGame;

public class MessagesTest : SimpleTest {

	// Use this for initialization
	void Start () {
		TestNotificationMessage();
	}
	
	void TestNotificationMessage()
	{
		if (showStatusDebug) Debug.Log("Begin " + ToString() + "/TestNotificationMessage");
		
		NotificationMessage msg = new NotificationMessage();
		msg.message = "Test message";
		msg.year = 2013;
		msg.month = 10;
		msg.day = 6;
		
		byte[] msgRaw = msg.ToBytes();
		
		NotificationMessage parsedMessage = new NotificationMessage();
		parsedMessage.FromBytes(msgRaw);
		
		AsserToStringEquals(msg, parsedMessage, "TestNotificationMessage");
		
		if (showStatusDebug) Debug.Log(ToString() + "/TestNotificationMessage complete");
	}
}
