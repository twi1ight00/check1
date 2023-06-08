using System;

namespace x5f3520a4b31ea90f;

internal class x2cf87a031823314d
{
	public static byte[] xc99bf7542a430c74(byte[] x08db3aeabb253cb1)
	{
		int num = 0;
		while (x08db3aeabb253cb1[num++] == 0 && num < x08db3aeabb253cb1.Length)
		{
		}
		num--;
		if (num > 0)
		{
			byte[] array = new byte[x08db3aeabb253cb1.Length - num];
			Buffer.BlockCopy(x08db3aeabb253cb1, num, array, 0, array.Length);
			return array;
		}
		return x08db3aeabb253cb1;
	}

	public static byte[] xdf0b52945cea7d94(byte[] x08db3aeabb253cb1, int x0ceec69a97f73617)
	{
		byte[] array = new byte[x0ceec69a97f73617];
		Buffer.BlockCopy(x08db3aeabb253cb1, 0, array, array.Length - x08db3aeabb253cb1.Length, x08db3aeabb253cb1.Length);
		return array;
	}

	public static byte[] x1add485e7984b4a9(x0c2c2ec0e5dfca9c x9a0352b710e06183, byte[] xe4115acdf4fbfccc)
	{
		return x9a0352b710e06183.x246b032720dd4c0d(xe4115acdf4fbfccc);
	}
}
