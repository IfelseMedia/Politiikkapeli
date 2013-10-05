using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class NetworkManagerClient : NetworkParticipant {
		void Start()
		{
			Initialize();
		}
		
		[RPC]
		void LogMessage(string message, NetworkMessageInfo messageInfo)
		{
			ServerMessageReceiver.AddMessage(message);
		}
		
		void OnConnectedToServer()
		{
			Debug.Log("Connected to server.");
			networkView.RPC("OnClientConnected", RPCMode.Server, network.localId);
		}
	}
	
}