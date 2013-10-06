using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

namespace PoliticsGame
{
	public class PartyMessage : NetworkMessage {
		public string id = string.Empty;
		public string viewCode = string.Empty;
		public string partyName = string.Empty;
		public Color partyColor = Color.white;
		public string value1 = string.Empty;
		public string value2 = string.Empty;
		public string value3 = string.Empty;
		
		#region implemented abstract members of NetworkMessage
		public override string ToComparisonString()
		{
			return id + " " + viewCode + " " + partyName + " " + partyColor + " " + value1 + " " + value2 + " " + value3;
		}
		
		public override string ToJson ()
		{
			List<object> data = new List<object>();
			data.Add(id);
			data.Add(viewCode);
			data.Add(partyName);
			data.Add((int)(partyColor.r));
			data.Add((int)(partyColor.g));
			data.Add((int)(partyColor.b));
			data.Add(value1);
			data.Add(value2);
			data.Add(value3);
			return Json.Serialize(data);
		}
	
		public override void FromJson (string json)
		{
			List<object> data = Json.Deserialize(json) as List<object>;
			
			id = (string)data[0];
			viewCode = (string)data[1];
			partyName = (string)data[2];
			partyColor = new Color(GetInt(data[3]), GetInt(data[4]), GetInt(data[5]));
			value1 = (string)data[6];
			value2 = (string)data[7];
			value3 = (string)data[8];
		}
		
		public override NetworkMessage GetNewInstance ()
		{
			return new PartyMessage();
		}
		#endregion
		public static byte[] CreateMessage(Party party)
		{
			PartyMessage msg = new PartyMessage();
			msg.id = party.partyId;
			msg.viewCode = party.viewCode;
			msg.partyName = party.partyName;
			msg.partyColor = party.partyColor;
			msg.value1 = party.value1;
			msg.value2 = party.value2;
			msg.value3 = party.value3;
			
			return msg.ToBytes();
		}
		
		public static Party CreateParty(byte[] bytes)
		{
			PartyMessage msg = new PartyMessage();
			msg.FromBytes(bytes);
			
			Party party = new Party();
			party.partyId = msg.id;
			party.partyName = msg.partyName;
			party.viewCode = msg.viewCode;
			party.partyColor = msg.partyColor;
			party.value1 = msg.value1;
			party.value2 = msg.value2;
			party.value3 = msg.value3;
			
			return party;
		}
	}
}