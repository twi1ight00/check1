using System;

namespace ns223;

internal class Class5984
{
	public static byte[] smethod_0(byte[] x)
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

	public static byte[] smethod_1(byte[] x, int size)
	{
		byte[] array = new byte[size];
		Buffer.BlockCopy(x, 0, array, array.Length - x.Length, x.Length);
		return array;
	}

	public static byte[] smethod_2(Class5986 rsa, byte[] s)
	{
		return rsa.Encrypt(s);
	}
}
