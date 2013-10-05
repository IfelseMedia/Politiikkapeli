using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

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
		return Zip.Compress(GetBytes(ToJson()));
	}
	
	public void FromBytes(byte[] bytes)
	{
		FromJson(GetString(Zip.Decompress(bytes)));
	}
	
	public abstract string ToJson();
	public abstract void FromJson(string json);
}
