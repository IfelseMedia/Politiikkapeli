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
	 
		public void StartServer()
		{
		    NetworkConnectionError error = Network.InitializeServer(100, 25000, !Network.HavePublicAddress());
			
			if (error != NetworkConnectionError.NoError) 
			{
				Debug.LogError(error);
				return;
			}
			
			server = gameManager.Root.AddComponent<NetworkManagerServer>();
			
			client = gameManager.Root.AddComponent<NetworkManagerClient>();
		}
		
		public void ConnectToServer(string ip, int port, string id)
		{
			HostData host = new HostData();
			host.ip = new string[]{ip};
			host.guid = id;
			NetworkConnectionError error = Network.Connect(ip, port);
			
			if (error != NetworkConnectionError.NoError) 
			{
				Debug.LogError(error);
				return;
			}
			
			client = gameManager.Root.AddComponent<NetworkManagerClient>();
		}
	}
}	