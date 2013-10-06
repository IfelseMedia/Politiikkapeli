using UnityEngine;
using System.Collections;

public class SimpleTest : MonoBehaviour {
	public bool showStatusDebug = false;
	public bool dumpDataToLog = false;
	
	public void AsserToStringEquals(object obj1, object obj2, string info)
	{
		if (obj1.ToString() != obj2.ToString())
			Debug.LogError(ToString() + " " + info + "\n" + obj1.ToString() + "\n" + obj2.ToString());
	}
	
	public void AsserToStringEquals(NetworkMessage obj1, NetworkMessage obj2, string info)
	{
		if (obj1.ToString() != obj2.ToString())
			Debug.LogError(ToString() + " " + info + "\n" + obj1.ToComparisonString() + "\n" + obj2.ToComparisonString());
	}
}
