using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	public class ServerMessageReceiver : PoliticsGameBehaviour
	{
		public static string msg = string.Empty;
		
		[RPC]
		void Test01(string message, NetworkMessageInfo messageInfo)
		{
			msg = message;
		}
	}
}