using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PoliticsGame
{	
	public class GameManager : PoliticsGameBehaviour 
	{	
		private GameObject _root;
		public GameObject Root
		{
			get
			{
				if (_root == null) _root = gameObject;
				
				return _root;
			}
		}
	
		public List<Party> parties;
		
		void Awake()
		{
			DontDestroyOnLoad(Root);
			
			gameManager = this;
			parties = new List<Party>();
		}
		
		public Party GetParty(string partyId)
		{
			if (parties == null) parties = new List<Party>();
			
			var party = from p in parties
						where p.partyId == partyId
						select p;
	
			return party.FirstOrDefault();
		}
		
		public Party GetPartyWithViewCode (string viewCode)
		{
			if (parties == null) parties = new List<Party>();
			
			var party = from p in parties
						where p.viewCode == viewCode
						select p;
	
			return party.FirstOrDefault();
		}
		
		public void AddOrUpdateParty(Party party)
		{
			if (parties == null) parties = new List<Party>();
			
			var found = (from p in parties
						where p.partyId == party.partyId
						select p).FirstOrDefault();
			
			if (found != null)
			{
				parties.Remove(found);
			}
			
			parties.Add(party);
		}
	}
}