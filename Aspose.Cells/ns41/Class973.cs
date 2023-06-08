using System;

namespace ns41;

internal class Class973
{
	public static byte[] smethod_0(byte[] byte_0)
	{
		int num = 0;
		while (byte_0[num++] == 0 && num < byte_0.Length)
		{
		}
		num--;
		if (num > 0)
		{
			byte[] array = new byte[byte_0.Length - num];
			Buffer.BlockCopy(byte_0, num, array, 0, array.Length);
			return array;
		}
		return byte_0;
	}

	public static byte[] smethod_1(byte[] byte_0, int int_0)
	{
		byte[] array = new byte[int_0];
		Buffer.BlockCopy(byte_0, 0, array, array.Length - byte_0.Length, byte_0.Length);
		return array;
	}

	public static byte[] smethod_2(Class974 class974_0, byte[] byte_0)
	{
		return class974_0.method_0(byte_0);
	}
}
