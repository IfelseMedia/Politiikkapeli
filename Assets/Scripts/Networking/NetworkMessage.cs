using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public abstract class NetworkMessage
{
	public NetworkMessage() 
	{
		
	}
	
	protected static byte[] GetBytes(string str)
	{
	    byte[] bytes = new byte[str.Length * sizeof(char)];
	    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
	    return bytes;
	}
	
	protected static string GetString(byte[] bytes)
	{
	    char[] chars = new char[bytes.Length / sizeof(char)];
	    System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
	    return new string(chars);
	}
		
	public byte[] ToBytes()
	{
		//return Zip.Compress(GetBytes(ToJson()));
		return GetBytes(ToJson());
	}
	
	public void FromBytes(byte[] bytes)
	{
		//FromJson(GetString(Zip.Decompress(bytes)));
		FromJson(GetString(bytes));
	}
	
	public static int GetInt(object rawData)
	{
		System.Int64 int64 = (System.Int64)rawData;
		return (int)int64;
	}
	
	public abstract NetworkMessage GetNewInstance();
	public abstract string ToComparisonString();
	public abstract string ToJson();
	public abstract void FromJson(string json);
}
