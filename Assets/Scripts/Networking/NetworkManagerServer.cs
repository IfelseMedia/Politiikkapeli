using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class NetworkManagerServer : NetworkParticipant {
	
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		void OnServerInitialized()
		{
		    Debug.Log("Server Initializied");
		}
	}
}