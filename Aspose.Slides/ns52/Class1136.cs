using System;
using System.IO;
using ns223;

namespace ns52;

internal class Class1136
{
	internal static byte[] smethod_0(byte[] x)
	{
		int num = 0;
		while (x[num++] == 0 && num < x.Length)
		{
		}
		num--;
		if (num > 0)
		{
			byte[] array = new byte[x.Length - num];
			Buffer.BlockCopy(x, num, array, 0, array.Length);
			return array;
		}
		return x;
	}

	internal static byte[] smethod_1(byte[] x, int size)
	{
		byte[] array = new byte[size];
		Buffer.BlockCopy(x, 0, array, array.Length - x.Length, x.Length);
		return array;
	}

	internal static byte[] smethod_2(Class1137 rsa, byte[] s)
	{
		return rsa.Encrypt(s);
	}

	internal static void smethod_3(byte[] keyModulus, byte[] keyExponent, byte[] message, byte[] signature)
	{
		if (signature.Length != keyModulus.Length)
		{
			Class1141.SignatureInvalidFlag = 1;
		}
		byte[] array = smethod_0(signature);
		Class1137 @class = new Class1137(keyModulus, keyExponent);
		byte[] array2 = smethod_2(@class, array);
		byte[] array3 = smethod_1(array2, @class.Modulus.method_0() >> 3);
		byte[] array4 = smethod_4(message, array3.Length);
		Class1138 class2 = new Class1138(array2);
		class2.method_0(array.Length, array4.Length, dummyParam3: false);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array2, 0, array2.Length);
		class2.method_2(memoryStream, array4, array.Length);
		if (class2.DummyField1)
		{
			array[0] = 0;
			array[1] = 17;
		}
		Class1139 class3 = new Class1139(class2, array3, dummyParam2: true, class2.DummyField1);
		int[] array5 = new int[array2.Length];
		Array.Copy(array2, 0, array5, 0, array2.Length);
		class3.method_2(array5, class2);
		class3.method_4(null, isDummy: true);
		class3.method_3(dummyParam1: true);
		class2.DummyField1 = true;
		string dummyParam = "1234567890ABCDEF";
		class3.method_4(dummyParam, isDummy: false);
		class3.method_1(array2, "Aspose.Words");
	}

	internal static byte[] smethod_4(byte[] message, int emLength)
	{
		Class5987 @class = new Class5987();
		byte[] array = @class.method_0(message);
		MemoryStream memoryStream = new MemoryStream();
		byte[] array2 = new byte[15]
		{
			48, 33, 48, 9, 6, 5, 43, 14, 3, 2,
			26, 5, 0, 4, 20
		};
		memoryStream.Write(array2, 0, array2.Length);
		memoryStream.Write(array, 0, array.Length);
		if (emLength < memoryStream.Length + 11L)
		{
			Class1141.SignatureInvalidFlag = 11;
		}
		MemoryStream memoryStream2 = new MemoryStream();
		memoryStream2.WriteByte(0);
		memoryStream2.WriteByte(1);
		int num = emLength - (int)memoryStream.Length - 3;
		for (int i = 0; i < num; i++)
		{
			memoryStream2.WriteByte(byte.MaxValue);
		}
		memoryStream2.WriteByte(0);
		memoryStream.WriteTo(memoryStream2);
		return memoryStream2.ToArray();
	}
}
