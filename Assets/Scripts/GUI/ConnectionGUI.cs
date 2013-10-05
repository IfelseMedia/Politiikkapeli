using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class ConnectionGUI : PoliticsGameBehaviour {
		
		public bool test = true;
		
		string ip = "127.0.0.1";
		string port = "25000";
		string id = "timo8";
		
		void OnGUI()
		{
			if (!Network.isServer && !Network.isClient)
			{
				if (GUI.Button(new Rect(10, 10, 200, 30), "Create new"))
				{
					network.StartServer();
				}
				ip = GUI.TextField(new Rect(220, 50, 200, 20), ip);
				port = GUI.TextField(new Rect(430, 50, 200, 20), port);
				if (GUI.Button(new Rect(10, 50, 200, 30), "Join"))
				{
					int portNum = 25000;
					System.Int32.TryParse(port, out portNum);
					network.ConnectToServer(ip, portNum, id);
				}
			}
			
			if (test)
			{
				if (Network.isServer)
				{
					GUI.Label(new Rect(10, 10, 300, 30), "ip: " + Network.player.ipAddress + " port: " + Network.player.port + " clients: " + Network.connections.Length);
				}
				else if (Network.isClient)
				{
					GUI.Label(new Rect(10, 50, 300, 30), "ip: " + Network.player.ipAddress + " port: " + Network.player.port);
				}
				
				GUI.Label(new Rect(10, 90, 300, 30), ServerMessageReceiver.msg);
			}
		}
	}
}