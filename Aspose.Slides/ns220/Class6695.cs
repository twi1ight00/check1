using System;
using System.IO;
using ns218;
using ns247;
using ns271;

namespace ns220;

internal static class Class6695
{
	public static Class6260 smethod_0(Class6733 fontSubset, string fontResourceName)
	{
		byte[] fontBytes;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			fontSubset.method_2(memoryStream, isMakeValidTtf: true, isFullEmbedding: false);
			fontBytes = Class5964.smethod_11(memoryStream);
		}
		return smethod_1(fontBytes, fontResourceName);
	}

	private static Class6260 smethod_1(byte[] fontBytes, string fontResourceName)
	{
		byte[] array = smethod_2(fontBytes, fontResourceName);
		Class6260 @class = new Class6260(fontResourceName, "application/vnd.ms-package.obfuscated-opentype");
		@class.Stream.Write(array, 0, array.Length);
		return @class;
	}

	private static byte[] smethod_2(byte[] fontBytes, string guidName)
	{
		byte[] array = smethod_3(guidName);
		for (int i = 0; i < 32; i++)
		{
			int num = array.Length - i % array.Length - 1;
			fontBytes[i] ^= array[num];
		}
		return fontBytes;
	}

	private static byte[] smethod_3(string fontName)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fontName);
		return Class5964.smethod_45(new Guid(fileNameWithoutExtension));
	}
}
