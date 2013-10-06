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
		void LogNotification(byte[] message, NetworkMessageInfo messageInfo)
		{
			if (debugRPCReceiving) Debug.Log("Receving RPC LogNotification");
			if (debugByteCounts) Debug.Log("Receiving " + message.Length + " bytes");
			
			NotificationMessage notification = new NotificationMessage();
			notification.FromBytes(message);
			
			ServerMessageReceiver.AddMessage(notification.ToString());
		}
		
		[RPC]
		void OnPartyUpdate(byte[] message, NetworkMessageInfo messageInfo)
		{
			if (debugRPCReceiving) Debug.Log("Receving RPC OnPartyUpdate");
			if (debugByteCounts) Debug.Log("Receiving " + message.Length + " bytes");
			
			Party partyData = PartyMessage.CreateParty(message);
			gameManager.AddOrUpdateParty(partyData);
		}
		
		void OnConnectedToServer()
		{
			Debug.Log("Connected to server. My viewcode: " + network.myViewCode);
			networkView.RPC("OnClientConnected", RPCMode.Server, network.myViewCode);
		}
	}
	
}