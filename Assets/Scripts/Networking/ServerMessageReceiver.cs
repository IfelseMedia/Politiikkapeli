using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class ServerMessageReceiver : PoliticsGameBehaviour
	{
		public static string msg = string.Empty;
		
		public static void AddMessage(string message)
		{
			msg = message;
		}
	}
}