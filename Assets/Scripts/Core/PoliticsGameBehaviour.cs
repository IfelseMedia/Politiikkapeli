using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace PoliticsGame
{
	public class PoliticsGameBehaviour : MonoBehaviour {
		private static Translator _translator;
		public static Translator translator
		{
			get 
			{
				if (_translator == null) _translator = new Translator();
				
				return _translator;
			}
		}
		
		[NonSerialized]
		public static GameManager gameManager;
		
		private static NetworkManager _network;
		public static NetworkManager network
		{
			get 
			{
				if (_network == null) _network = gameManager.Root.AddComponent<NetworkManager>();
				
				return _network;
			}
		}
		
		public string Text(string text, params string[] tokens) 
		{
			return translator.Get(text, tokens);
		}
		
		private static T GetManagerComponent<T>(ref T targetVar) where T : MonoBehaviour
		{
			if (targetVar == null)
			{
				if (gameManager == null) Debug.LogError("Null gameManager"); 
				else if (gameManager.Root == null) Debug.LogError("GameManager has no root");
				else targetVar = gameManager.Root.AddComponent<T>();
			}
			
			return targetVar;
		}
	}
}
