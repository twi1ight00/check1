using System;
using System.IO;
using ns4;

namespace ns59;

internal class Class2611
{
	public uint uint_0;

	public uint uint_1;

	public byte[] byte_0;

	public uint uint_2;

	public Class2610[] class2610_0;

	internal int method_0()
	{
		int num = 0;
		for (int i = 0; i < class2610_0.Length; i++)
		{
			num += class2610_0[i].method_0();
		}
		return 8 + byte_0.Length + 4 + num;
	}

	internal byte[] method_1(Class2616 rc4DecryptorFactory)
	{
		byte[] array = new byte[method_0()];
		byte[] data = new byte[8];
		Class1162.smethod_16(data, 0, (int)uint_0);
		Class1162.smethod_16(data, 4, (int)uint_1);
		Class2615 @class = rc4DecryptorFactory.method_0(0u);
		byte[] array2 = @class.Encrypt(data);
		Array.Copy(array2, 0, array, 0, array2.Length);
		Array.Copy(byte_0, 0, array, 8, byte_0.Length);
		byte[] array3 = new byte[uint_1];
		Class1162.smethod_16(array3, 0, (int)uint_2);
		int i = 0;
		int num = 4;
		for (; i < class2610_0.Length; i++)
		{
			class2610_0[i].method_1(num, array3);
			num += class2610_0[i].method_0();
		}
		Class2615 class2 = rc4DecryptorFactory.method_0(0u);
		byte[] array4 = class2.Encrypt(array3);
		Array.Copy(array4, 0, array, 8 + byte_0.Length, array4.Length);
		return array;
	}

	public static Class2611 smethod_0(Stream stream, Class2616 rc4DecryptorFactory)
	{
		Class2611 @class = new Class2611();
		Class2615 class2 = rc4DecryptorFactory.method_0(0u);
		byte[] encryptedData = Class1162.smethod_28(stream, 8);
		byte[] value = class2.method_0(encryptedData);
		@class.uint_0 = BitConverter.ToUInt32(value, 0);
		@class.uint_1 = BitConverter.ToUInt32(value, 4);
		uint size = @class.uint_0 - 8;
		@class.byte_0 = Class1162.smethod_28(stream, (int)size);
		Class2615 class3 = rc4DecryptorFactory.method_0(0u);
		byte[] encryptedData2 = Class1162.smethod_28(stream, (int)@class.uint_1);
		byte[] buffer = class3.method_0(encryptedData2);
		using Stream stream2 = new MemoryStream(buffer);
		@class.uint_2 = (uint)Class1162.smethod_24(stream2);
		@class.class2610_0 = new Class2610[@class.uint_2];
		uint num = 8u;
		for (int i = 0; i != @class.uint_2; i++)
		{
			Class2610 class4 = Class2610.smethod_0(stream2);
			num += class4.uint_1;
			@class.class2610_0[i] = class4;
		}
		return @class;
	}

	public byte[] method_2(Class2616 rc4DecryptorFactory, uint index)
	{
		Class2610 @class = class2610_0[index];
		byte[] array = new byte[@class.uint_1];
		Array.Copy(byte_0, @class.uint_0 - 8, array, 0L, @class.uint_1);
		Class2615 class2 = rc4DecryptorFactory.method_0(index);
		return class2.method_0(array);
	}
}
