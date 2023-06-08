using System;

namespace ns11;

internal class Class1650
{
	private byte[] byte_0;

	private Class1642 class1642_0;

	private Class1646 class1646_0;

	public Class1650()
	{
		class1642_0 = Class1639.smethod_0(Enum220.const_1, Enum222.const_2);
		class1646_0 = Class1643.smethod_0(Enum224.const_0);
		byte_0 = new byte[16];
	}

	public void method_0(ushort[] ushort_0, byte[] byte_1)
	{
		byte[] array = new byte[64];
		int i = 0;
		for (int num = 16; i < num && ushort_0[i] != 0; i++)
		{
			array[2 * i] = (byte)(ushort_0[i] & 0xFFu);
			array[2 * i + 1] = (byte)((uint)(ushort_0[i] >> 8) & 0xFFu);
		}
		array[2 * i] = 128;
		array[56] = (byte)(i << 4);
		Class1643.smethod_1(class1646_0, array, 0u, (uint)array.Length);
		Class1643.smethod_2(class1646_0, array, 16u);
		for (i = 0; i < 16; i++)
		{
			Class1643.smethod_1(class1646_0, array, 0u, 5u);
			Class1643.smethod_1(class1646_0, byte_1, 0u, 16u);
		}
		array[16] = 128;
		Array.Clear(array, 17, array.Length - 17);
		array[56] = 128;
		array[57] = 10;
		Class1643.smethod_1(class1646_0, array, 16u, (uint)(array.Length - 16));
		Class1643.smethod_2(class1646_0, byte_0, (uint)byte_0.Length);
	}

	public void method_1(byte[] byte_1, byte[] byte_2)
	{
		method_2(0u);
		byte[] array = new byte[16];
		byte[] array2 = new byte[64];
		Class1639.smethod_3(class1642_0, byte_1, 0u, 16u, array2, 0u, (uint)array2.Length);
		array2[16] = 128;
		Array.Clear(array2, 17, array2.Length - 17);
		array2[56] = 128;
		Class1643.smethod_1(class1646_0, array2, 0u, (uint)array2.Length);
		Class1643.smethod_2(class1646_0, array, (uint)array.Length);
		Class1639.smethod_3(class1642_0, byte_2, 0u, 16u, array2, 0u, (uint)array2.Length);
		if (!Class1649.smethod_1(array2, array, (uint)array.Length))
		{
			throw new ApplicationException("Invalid password.");
		}
	}

	public bool method_2(uint uint_0)
	{
		byte[] array = new byte[64];
		Array.Copy(byte_0, array, 5);
		array[5] = (byte)(uint_0 & 0xFFu);
		array[6] = (byte)((uint_0 >> 8) & 0xFFu);
		array[7] = (byte)((uint_0 >> 16) & 0xFFu);
		array[8] = (byte)((uint_0 >> 24) & 0xFFu);
		array[9] = 128;
		array[56] = 72;
		class1642_0 = Class1639.smethod_0(Enum220.const_1, Enum222.const_2);
		class1646_0 = Class1643.smethod_0(Enum224.const_0);
		Class1643.smethod_1(class1646_0, array, 0u, (uint)array.Length);
		Class1643.smethod_2(class1646_0, array, 16u);
		Enum223 @enum = Class1639.smethod_1(class1642_0, Enum221.const_1, array, 16u, null, 0u);
		return @enum == Enum223.const_0;
	}

	public bool method_3(byte[] byte_1, uint uint_0, uint uint_1, byte[] byte_2, uint uint_2, uint uint_3)
	{
		Enum223 @enum = Class1639.smethod_3(class1642_0, byte_1, uint_0, uint_1, byte_2, uint_2, uint_3);
		return @enum == Enum223.const_0;
	}

	public bool method_4(uint uint_0)
	{
		byte[] array = new byte[1024];
		uint num = uint_0;
		bool flag = true;
		while (flag && num != 0)
		{
			uint num2 = (uint)Math.Min(num, array.Length);
			flag = method_3(array, 0u, num2, array, 0u, num2);
			num -= num2;
		}
		return flag;
	}
}
