using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class NetworkManagerServer : NetworkParticipant {
		NetworkView netview;
		
		// Use this for initialization
		void Start () {
			netview = networkView;
			
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
			netview.RPC("Test01", RPCMode.All, msg);
		}
		
		void OnServerInitialized()
		{
		    Debug.Log("Server Initializied");
		}
	}
}