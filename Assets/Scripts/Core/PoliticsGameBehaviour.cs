using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace PoliticsGame
{
	public class PoliticsGameBehaviour : MonoBehaviour {
		private Translator _translator;
		public Translator translator
		{
			get 
			{
				if (_translator == null) _translator = new Translator();
				
				return _translator;
			}
		}
		
		public GameManager gameManager;
		
		private NetworkManager _network;
		public NetworkManager network
		{
			get { return GetManagerComponent<NetworkManager>(_network); }
		}
		
		public string Text(string text, params string[] tokens) 
		{
			return translator.Get(text, tokens);
		}
		
		private T GetManagerComponent<T>(T targetVar) where T : MonoBehaviour
		{
			if (targetVar == null)
			{
				targetVar = gameManager.Root.AddComponent<T>();
			}
			
			return targetVar;
		}
	}
}
