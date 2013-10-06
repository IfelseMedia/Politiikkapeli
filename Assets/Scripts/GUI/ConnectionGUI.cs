using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class ConnectionGUI : PoliticsGameBehaviour {
		
		public bool test = true;
		
		string ip = "127.0.0.1";
		string port = "25000";
		string id = "";
		
		void Start()
		{
			 id = Text ("syötä puoluekoodi");
		}
		
		void OnGUI()
		{
			if (!Network.isServer && !Network.isClient)
			{
				if (GUI.Button(new Rect(10, 10, 200, 30), "Create new"))
				{
					network.StartServer();
				}
				ip = GUI.TextField(new Rect(220, 50, 120, 20), ip);
				port = GUI.TextField(new Rect(350, 50, 100, 20), port);
				id = GUI.TextField(new Rect(460, 50, 100, 20), id);
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