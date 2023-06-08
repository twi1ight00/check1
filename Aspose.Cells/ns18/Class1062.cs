using System;
using System.IO;
using ns22;

namespace ns18;

internal class Class1062
{
	public static Class1051 smethod_0(Class1077 class1077_0, string string_0)
	{
		byte[] byte_;
		using (MemoryStream stream_ = new MemoryStream())
		{
			class1077_0.method_1(stream_, bool_0: true, bool_1: false);
			byte_ = Class936.smethod_1(stream_, bool_0: false);
		}
		return smethod_1(byte_, string_0);
	}

	private static Class1051 smethod_1(byte[] byte_0, string string_0)
	{
		byte[] array = smethod_2(byte_0, string_0);
		Class1051 @class = new Class1051(string_0, "application/vnd.ms-package.obfuscated-opentype");
		@class.method_1().Write(array, 0, array.Length);
		return @class;
	}

	private static byte[] smethod_2(byte[] byte_0, string string_0)
	{
		byte[] array = smethod_3(string_0);
		for (int i = 0; i < 32; i++)
		{
			int num = array.Length - i % array.Length - 1;
			byte_0[i] ^= array[num];
		}
		return byte_0;
	}

	private static byte[] smethod_3(string string_0)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_0);
		string text = new Guid(fileNameWithoutExtension).ToString("N");
		byte[] array = new byte[16];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)Class1025.smethod_2(text.Substring(i * 2, 2));
		}
		return array;
	}
}
