using System.IO;
using System.IO.Compression;

public static class Zip
{
    public static byte[] Decompress(byte[] zippedData)
    {
        byte[] decompressedData = null;
        using (MemoryStream outputStream = new MemoryStream())
        {
            using (MemoryStream inputStream = new MemoryStream(zippedData))
            {
                using (GZipStream zip = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                   CopyTo(zip, outputStream);
                }
            }
            decompressedData = outputStream.ToArray();
        }

        return decompressedData;
    }
	
	public static void CopyTo(Stream input, Stream output)
    {
        byte[] buffer = new byte[16 * 1024];
        int bytesRead;
        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, bytesRead);
        }
    }

    public static byte[] Compress(byte[] plainData)
    {
        byte[] compressesData = null;
        using (MemoryStream outputStream = new MemoryStream())
        {
            using (GZipStream zip = new GZipStream(outputStream, CompressionMode.Compress))
            {
                zip.Write(plainData, 0, plainData.Length);                    
            }
            //Dont get the MemoryStream data before the GZipStream is closed 
            //since it doesn’t yet contain complete compressed data.
            //GZipStream writes additional data including footer information when its been disposed
            compressesData = outputStream.ToArray();
        }

        return compressesData;
    }

}