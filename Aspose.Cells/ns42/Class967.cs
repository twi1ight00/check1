using System;
using System.IO;
using ns41;

namespace ns42;

internal class Class967
{
	private byte[] byte_0;

	private byte[] byte_1;

	internal Class967(byte[] byte_2, byte[] byte_3)
	{
		byte_0 = byte_2;
		byte_1 = byte_3;
	}

	internal void method_0(byte[] byte_2, byte[] byte_3)
	{
		smethod_0(byte_0, byte_1, byte_2, byte_3);
	}

	private static void smethod_0(byte[] byte_2, byte[] byte_3, byte[] byte_4, byte[] byte_5)
	{
		if (byte_5.Length != byte_2.Length)
		{
			Class971.smethod_2(1);
		}
		byte[] array = Class973.smethod_0(byte_5);
		Class974 @class = new Class974(byte_2, byte_3);
		byte[] array2 = Class973.smethod_2(@class, array);
		byte[] array3 = Class973.smethod_1(array2, @class.method_1().method_0() >> 3);
		byte[] array4 = smethod_1(byte_4, array3.Length);
		Class968 class2 = new Class968(array2);
		class2.method_0(array.Length, array4.Length, bool_1: false);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array2, 0, array2.Length);
		class2.method_2(memoryStream, array4, array.Length);
		if (class2.method_3())
		{
			array[0] = 0;
			array[1] = 17;
		}
		Class969 class3 = new Class969(class2, array3, bool_0: true, class2.method_3());
		int[] array5 = new int[array2.Length];
		Array.Copy(array2, 0, array5, 0, array2.Length);
		class3.method_2(array5, class2);
		class3.method_4(null, bool_0: true);
		class3.method_3(bool_0: true);
		class2.method_4(bool_1: true);
		string string_ = "1234567890ABCDEF";
		class3.method_4(string_, bool_0: false);
		class3.method_1(array2, "Aspose.Words");
	}

	internal static byte[] smethod_1(byte[] byte_2, int int_0)
	{
		Class975 @class = new Class975();
		byte[] array = @class.method_0(byte_2);
		MemoryStream memoryStream = new MemoryStream();
		byte[] array2 = new byte[15]
		{
			48, 33, 48, 9, 6, 5, 43, 14, 3, 2,
			26, 5, 0, 4, 20
		};
		memoryStream.Write(array2, 0, array2.Length);
		memoryStream.Write(array, 0, array.Length);
		if (int_0 < memoryStream.Length + 11)
		{
			Class971.smethod_2(11);
		}
		MemoryStream memoryStream2 = new MemoryStream();
		memoryStream2.WriteByte(0);
		memoryStream2.WriteByte(1);
		int num = int_0 - (int)memoryStream.Length - 3;
		for (int i = 0; i < num; i++)
		{
			memoryStream2.WriteByte(byte.MaxValue);
		}
		memoryStream2.WriteByte(0);
		memoryStream.WriteTo(memoryStream2);
		return memoryStream2.ToArray();
	}
}
