using UnityEngine;
using System.Collections;
using PoliticsGame;

public class JsonTest : SimpleTest 
{
	void Start () {
		TestNotificationMessage();
		TestPartyMessage();
	}
	
	void TestNotificationMessage()
	{
		string testName = "TestNotificationMessage";
		if (showStatusDebug) Debug.Log("Begin " + ToString() + "/" + testName);
		
		NotificationMessage msg = new NotificationMessage();
		msg.message = "Test message";
		msg.year = 2013;
		msg.month = 10;
		msg.day = 6;
		
		AssertTestJson(msg, testName);
		
		if (showStatusDebug) Debug.Log(ToString() + "/" + testName + " complete");
	}
	
	void TestPartyMessage()
	{
		string testName = "TestPartyMessage";
		if (showStatusDebug) Debug.Log("Begin " + ToString() + "/" + testName);
		
		PartyMessage msg = new PartyMessage();
		msg.id = "party1";
		msg.viewCode = "player1";
		msg.partyName = "PRT";
		msg.partyColor = new Color(10, 120, 250);
		msg.value1 = "val-1";
		msg.value2 = "val-2";
		msg.value3 = "val-3";
		
		AssertTestJson(msg, testName);
		
		if (showStatusDebug) Debug.Log(ToString() + "/" + testName + " complete");
	}
	
	void AssertTestJson(NetworkMessage msg, string testName)
	{
		string asJson = msg.ToJson();
		
		if (dumpDataToLog) Debug.Log("asJson: " + asJson);
		
		var newMsg = msg.GetNewInstance();
		newMsg.FromJson(asJson);
		
		if (dumpDataToLog) Debug.Log("Parsed from asJson: " + newMsg.ToComparisonString());
		
		if (showStatusDebug) AsserToStringEquals(msg, newMsg, testName);
	}
}
