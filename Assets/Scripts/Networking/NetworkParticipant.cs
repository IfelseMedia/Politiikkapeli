using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PoliticsGame
{
	public abstract class NetworkParticipant : PoliticsGameBehaviour
	{
		protected const string typeName = "FinnishPoliticsGame";
		protected Dictionary<NetworkPlayer, string> connectedClients;
		protected NetworkView netview;
		
		protected void Initialize()
		{
			netview = networkView;
			
			connectedClients = new Dictionary<NetworkPlayer, string>();
		}
		
		[RPC]
		void OnClientConnected(string message, NetworkMessageInfo messageInfo)
		{
			if (!connectedClients.ContainsKey(messageInfo.sender))
			{
				connectedClients.Add(messageInfo.sender, message);
				netview.RPC("LogMessage", messageInfo.sender, "Welcome " + message + "!");
			}
		}
	}
}
