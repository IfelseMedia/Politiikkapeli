using UnityEngine;
using System.Collections;

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
		
		void Awake()
		{
			gameManager = this;
		}
	}
}