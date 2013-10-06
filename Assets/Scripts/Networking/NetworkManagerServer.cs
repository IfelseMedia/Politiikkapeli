using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PoliticsGame
{
	public class NetworkManagerServer : NetworkParticipant {
		
		void Start () {
			Initialize();
			
			GameObject go = new GameObject("GameMaster");
			go.transform.parent = gameManager.Root.transform;
			go.AddComponent<GameMaster.GameMaster>();
			
			//StartCoroutine(TestRPC());
		}
		
		IEnumerator TestRPC()
		{
			int count = 0;
			
			while (count < 100)
			{
				count ++;
				BroadcastNotification(new NotificationMessage("Test message " + count, 2013, 10, 6));
				yield return new WaitForSeconds(5);
			}
		}
		
		void OnServerInitialized()
		{
		    Debug.Log("Server Initializied");
		}
		
		public void BroadcastNotification(NotificationMessage notification)
		{
			if (debugRPCSending) Debug.Log("Sending RPC BroadcastNotification");
			if (debugByteCounts) Debug.Log("Broadcasting " + notification.ToBytes().Length + " bytes");
			netview.RPC("LogNotification", RPCMode.AllBuffered, notification.ToBytes());
		}
	
		public void SendUpdateParty(Party party, NetworkPlayer player)
		{
			if (debugRPCSending) Debug.Log("Sending RPC SendUpdateParty");
			byte[] message = PartyMessage.CreateMessage(party);
			netview.RPC("OnPartyUpdate", player, message);
			//BroadcastNotification(new NotificationMessage("Added party " + party.partyName));
		}
		
		public void UpdateParty(Party party)
		{
			if (debugRPCSending) Debug.Log("Sending RPC UpdateParty");
			byte[] message = PartyMessage.CreateMessage(party);
			netview.RPC("OnPartyUpdate", RPCMode.Others, message);
			BroadcastNotification(new NotificationMessage("Added party " + party.partyName));
		}
	}
}