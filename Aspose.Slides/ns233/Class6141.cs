using System;
using System.Collections;
using System.IO;
using ns218;
using ns224;
using ns234;

namespace ns233;

internal class Class6141
{
	internal const int int_0 = 8;

	private static readonly byte[] byte_0;

	private static readonly Hashtable hashtable_0;

	private static readonly object object_0;

	private Class6141()
	{
	}

	static Class6141()
	{
		hashtable_0 = new Hashtable();
		object_0 = new object();
		using Stream stream = Class6166.smethod_0("Aspose.Resources.HatchMasks.dat");
		byte_0 = new byte[(int)stream.Length];
		stream.Read(byte_0, 0, byte_0.Length);
	}

	public static byte[] smethod_0(Class5996 brush)
	{
		string key = smethod_2(brush);
		byte[] array;
		lock (object_0)
		{
			array = (byte[])hashtable_0[key];
		}
		if (array == null)
		{
			lock (object_0)
			{
				array = (byte[])hashtable_0[key];
				if (array == null)
				{
					array = smethod_1(brush);
					hashtable_0[key] = array;
				}
			}
		}
		return array;
	}

	private static byte[] smethod_1(Class5996 brush)
	{
		byte[] array = new byte[8];
		Array.Copy(byte_0, (int)brush.HatchStyle * 8, array, 0, 8);
		using Class6150 @class = new Class6150(8, 8);
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				Class5998 color = (((array[i] & (128 >> j)) > 0) ? brush.ForegroundColor : brush.BackgroundColor);
				@class.method_3(j, 7 - i, color);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		@class.Save(memoryStream, Enum788.const_5);
		return Class5964.smethod_11(memoryStream);
	}

	private static string smethod_2(Class5996 brush)
	{
		return $"{brush.HatchStyle}{brush.BackgroundColor.method_1():X}{brush.ForegroundColor.method_1():X}";
	}
}
