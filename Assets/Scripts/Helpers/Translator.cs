using UnityEngine;
using System.Collections;

namespace PoliticsGame
{
	/// <summary>
	/// Dummy class for localization.
	/// TODO: implement actual localization.
	/// </summary>
	public class Translator
	{
		/// <summary>
		/// Translates the text into the current language.
		/// Currently returns the text as such.
		/// </summary>
		public string Get(string text, params string[] tokens)
		{
			return string.Format(text, tokens);
		}
	}
}