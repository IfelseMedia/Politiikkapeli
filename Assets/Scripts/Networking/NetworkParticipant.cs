using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PoliticsGame
{
	public abstract class NetworkParticipant : PoliticsGameBehaviour
	{
		public static bool debugByteCounts = false;
		public static bool debugRPCSending = false;
		public static bool debugRPCReceiving = false;
		
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
			if (debugRPCReceiving) Debug.Log("Received RPC OnClientConnected");
			
			if (!connectedClients.ContainsKey(messageInfo.sender))
			{
				Debug.Log("New client added with viewcode " + message);
				
				Party connectedParty = gameManager.GetPartyWithViewCode(message);
				
				if (connectedParty == null)
				{
					Debug.Log("Anonymous login");
				}
				else 
				{
					connectedClients.Add(messageInfo.sender, message);
					
					NotificationMessage notification = new NotificationMessage("Tervetuloa " + connectedParty.partyName + "!");
				
					SendNotification(messageInfo.sender, notification);
				}
				
				for (int i = 0; i < gameManager.parties.Count; i++)
				{
					network.server.SendUpdateParty(gameManager.parties[i], messageInfo.sender);
				}
			}
		}
		
		[RPC]
		void OnRequestParties(NetworkMessageInfo info)
		{
			if (debugRPCReceiving) Debug.Log("OnRequestParties");
			for (int i = 0; i < gameManager.parties.Count; i++)
			{
				network.server.SendUpdateParty(gameManager.parties[i], info.sender);
			}
		}
		
		public void SendNotification(NetworkPlayer receiver, NotificationMessage notification)
		{
			if (debugRPCSending) Debug.Log("Sending RPC SendNotification");
			if (debugByteCounts) Debug.Log("Sending " + notification.ToBytes().Length + " bytes");
			netview.RPC("LogNotification", receiver, notification.ToBytes());
		}
		
		public void RequestParties()
		{
			if (debugRPCSending) Debug.Log("Sending RPC RequestParties");
			netview.RPC("OnRequestParties", RPCMode.Server);
		}
	}
}
