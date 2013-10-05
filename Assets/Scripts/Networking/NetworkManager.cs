using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class NetworkManager : PoliticsGameBehaviour 
	{
		[System.NonSerialized]
		public NetworkManagerClient client;
		
		[System.NonSerialized]
		public NetworkManagerServer server;
		
		public string localId = "timo8";
		
		public void StartServer()
		{
		    NetworkConnectionError error = Network.InitializeServer(100, 25000, !Network.HavePublicAddress());
			
			if (error != NetworkConnectionError.NoError) 
			{
				Debug.LogError(error);
				return;
			}
			
			if (server) Destroy(server);
			
			server = gameManager.Root.AddComponent<NetworkManagerServer>();
			
			if (client) Destroy(client);
			
			client = gameManager.Root.AddComponent<NetworkManagerClient>();
		}
		
		public void ConnectToServer(string ip, int port, string id)
		{
			NetworkConnectionError error = Network.Connect(ip, port);
			
			if (error != NetworkConnectionError.NoError) 
			{
				Debug.LogError(error);
				return;
			}
			
			this.localId = id;
			
			if (client) Destroy(client);
			
			client = gameManager.Root.AddComponent<NetworkManagerClient>();
		}
	}
}	