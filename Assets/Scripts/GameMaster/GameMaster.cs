using UnityEngine;
using System.Collections;
using PoliticsGame;

namespace PoliticsGame.GameMaster
{
	public class GameMaster : PoliticsGameBehaviour
	{
		public void Start()
		{
			Party p1 = new Party();
			p1.partyId = "p1";
			p1.partyName = "Party 1";
			p1.viewCode = "party-1";
			p1.partyColor = Color.green;
			p1.value1 = "Value-1";
			p1.value2 = "Value-2";
			p1.value3 = "Value-3";
			
			Party p2 = new Party();
			p2.partyId = "p2";
			p2.partyName = "Party 2";
			p2.viewCode = "party-2";
			p2.partyColor = Color.green;
			p2.value1 = "Value-2";
			p2.value2 = "Value-3";
			p2.value3 = "Value-4";
			
			Party p3 = new Party();
			p3.partyId = "p3";
			p3.partyName = "Party 3";
			p3.viewCode = "party-3";
			p3.partyColor = Color.green;
			p3.value1 = "Value-3";
			p3.value2 = "Value-4";
			p3.value3 = "Value-5";
			
			AddOrUpdateParty(p1);
			AddOrUpdateParty(p2);
			AddOrUpdateParty(p3);
		}
		
		public void AddOrUpdateParty(Party partyData)
		{
			gameManager.AddOrUpdateParty(partyData);
			network.server.UpdateParty(partyData);
		}
	}
}