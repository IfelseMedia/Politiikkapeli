using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class NetworkManager : PoliticsGameBehaviour 
	{
		public NetworkParticipant connection;
		
		void Start()
		{
			
			
		}
		
	 
		public void StartServer()
		{
		    NetworkConnectionError error = Network.InitializeServer(100, 25000, !Network.HavePublicAddress());
			
			if (error != null) Debug.LogError(error);
			
			connection = gameManager.Root.AddComponent<NetworkManagerServer>();
		}
		
		public void ConnectToServer(string ip, string id)
		{
			
		}
	}
}	