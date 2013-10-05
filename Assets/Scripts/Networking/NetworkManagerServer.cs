using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PoliticsGame
{
	public class NetworkManagerServer : NetworkParticipant {
		
		void Start () {
			Initialize();
			
			StartCoroutine(TestRPC());
		}
		
		IEnumerator TestRPC()
		{
			int count = 0;
			
			while (count < 100)
			{
				count ++;
				TestRPC("Test message " + count);
				yield return new WaitForSeconds(5);
			}
		}
		
		void TestRPC(string msg)
		{
			Debug.Log("Sent message " + msg);
			netview.RPC("LogMessage", RPCMode.AllBuffered, msg);
		}
		
		void OnServerInitialized()
		{
		    Debug.Log("Server Initializied");
		}
		
		
	}
}