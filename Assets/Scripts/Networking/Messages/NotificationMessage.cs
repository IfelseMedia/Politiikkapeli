using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

namespace PoliticsGame
{
	public class NotificationMessage : NetworkMessage
	{	
		public string message;
		public int year;
		public int month;
		public int day;
		
		public NotificationMessage() {}
		public NotificationMessage(string message)
		{
			this.message = message;
			this.year = System.DateTime.Now.Year;
			this.month = System.DateTime.Now.Month;
			this.day = System.DateTime.Now.Day;
		}
		public NotificationMessage(string message, int year, int month, int day)
		{
			this.message = message;
			this.year = year;
			this.month = month;
			this.day = day;
		}
		
		public new string ToString()
		{
			return year + "-" + month + "-" + day + ": " + message;
		}
		
		#region implemented abstract members of NetworkMessage
		public override string ToComparisonString()
		{
			return ToString();
		}
		
		public override string ToJson ()
		{
			List<object> data = new List<object>();
			data.Add(message);
			data.Add(year);
			data.Add(month);
			data.Add(day);
			string json = Json.Serialize(data);
			return json;
		}

		public override void FromJson (string json)
		{
			List<object> data = Json.Deserialize(json) as List<object>;
			
			message = (string)data[0];
			year = GetInt(data[1]);
			month = GetInt(data[2]);
			day = GetInt(data[3]);
		}
		
		public override NetworkMessage GetNewInstance ()
		{
			return new NotificationMessage();
		}
		#endregion
	}
}

 //  public class MiniJSONTest : MonoBehaviour {
    //      void Start () {
    //          var jsonString = "{ \"array\": [1.44,2,3], " +
    //                          "\"object\": {\"key1\":\"value1\", \"key2\":256}, " +
    //                          "\"string\": \"The quick brown fox \\\"jumps\\\" over the lazy dog \", " +
    //                          "\"unicode\": \"\\u3041 Men\u00fa sesi\u00f3n\", " +
    //                          "\"int\": 65536, " +
    //                          "\"float\": 3.1415926, " +
    //                          "\"bool\": true, " +
    //                          "\"null\": null }";
    //
    //          var dict = Json.Deserialize(jsonString) as Dictionary<string,object>;
    //
    //          Debug.Log("deserialized: " + dict.GetType());
    //          Debug.Log("dict['array'][0]: " + ((List<object>) dict["array"])[0]);
    //          Debug.Log("dict['string']: " + (string) dict["string"]);
    //          Debug.Log("dict['float']: " + (double) dict["float"]); // floats come out as doubles
    //          Debug.Log("dict['int']: " + (long) dict["int"]); // ints come out as longs
    //          Debug.Log("dict['unicode']: " + (string) dict["unicode"]);
    //
    //          var str = Json.Serialize(dict);
    //
    //          Debug.Log("serialized: " + str);
    //      }
    //  }