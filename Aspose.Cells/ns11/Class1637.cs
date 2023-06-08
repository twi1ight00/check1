using System;

namespace ns11;

internal class Class1637
{
	private byte[] byte_0;

	public Class1637(string string_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			if (string_0.Length > 15)
			{
				throw new ArgumentException("The password can not be more than 15 characters.");
			}
			byte_0 = smethod_3(string_0, smethod_2(string_0));
			return;
		}
		throw new ArgumentException("The password could not be null or empty.");
	}

	public byte[] method_0(byte[] byte_1, int int_0, short short_0)
	{
		byte b = (byte)((uint)(int_0 + short_0) & 0xFu);
		byte[] array = new byte[short_0];
		for (int i = 0; i < short_0; i++)
		{
			byte b2 = (byte)(byte_1[i] ^ byte_0[b]);
			byte b3 = (byte)(b2 << 5);
			b2 = (byte)(b2 >> 3);
			b2 = (byte)(b2 | b3);
			array[i] = b2;
			b = (byte)((uint)(b + 1) & 0xFu);
		}
		return array;
	}

	public byte[] Decrypt(byte[] byte_1, int int_0, short short_0)
	{
		byte b = (byte)((uint)(int_0 + short_0) & 0xFu);
		byte[] array = new byte[short_0];
		for (int i = 0; i < short_0; i++)
		{
			byte b2 = byte_1[i];
			byte b3 = (byte)(b2 >> 5);
			b2 = (byte)(b2 << 3);
			b2 = (byte)(b2 | b3);
			array[i] = (byte)(b2 ^ byte_0[b]);
			b = (byte)((uint)(b + 1) & 0xFu);
		}
		return array;
	}

	public static bool smethod_0(string string_0, ushort ushort_0, ushort ushort_1)
	{
		if (smethod_1(string_0) == ushort_0 && smethod_2(string_0) == ushort_1)
		{
			return true;
		}
		return false;
	}

	public static ushort smethod_1(string string_0)
	{
		ushort num = 0;
		int num2 = 0;
		while (num2 < string_0.Length)
		{
			ushort num3 = string_0[num2];
			num2++;
			ushort num4 = (ushort)(num3 & 0x8000u);
			int num5 = num2 % 15;
			num3 = (ushort)(num3 & 0x7FFFu);
			ushort num6 = (ushort)(num3 >> 15 - num5);
			num3 = (ushort)((ushort)(num3 << num5) | num6);
			num3 = (ushort)(num3 & 0x7FFFu);
			num3 = (ushort)(num3 | num4);
			num = (ushort)(num ^ num3);
		}
		return (ushort)((uint)(num ^ string_0.Length) ^ 0xCE4Bu);
	}

	public static ushort smethod_2(string string_0)
	{
		ushort num = 0;
		ushort num2 = 32768;
		ushort num3 = ushort.MaxValue;
		ushort num4 = 0;
		int length = string_0.Length;
		while (num4 < length)
		{
			ushort num5 = string_0[length - 1 - num4];
			num5 = (ushort)(num5 & 0x7Fu);
			for (int i = 0; i < 8; i++)
			{
				ushort num6 = (ushort)(num2 >> 15);
				num2 = (ushort)(num2 << 1);
				num2 = (ushort)(num2 | num6);
				if (num6 != 0)
				{
					num2 = (ushort)(num2 ^ 0x1020u);
				}
				num6 = (ushort)(num3 >> 15);
				num3 = (ushort)(num3 << 1);
				num3 = (ushort)(num3 | num6);
				if (num6 != 0)
				{
					num3 = (ushort)(num3 ^ 0x1020u);
				}
				if ((num5 & (1 << i)) != 0)
				{
					num = (ushort)(num ^ num2);
				}
			}
			num4 = (ushort)(num4 + 1);
		}
		return (ushort)(num ^ num3);
	}

	private static byte[] smethod_3(string string_0, ushort ushort_0)
	{
		int length = string_0.Length;
		byte[] array = new byte[16];
		for (int i = 0; i < length; i++)
		{
			array[i] = (byte)string_0[i];
		}
		byte[] array2 = new byte[15]
		{
			187, 255, 255, 186, 255, 255, 185, 128, 0, 190,
			15, 0, 191, 15, 0
		};
		for (int j = length; j < 16; j++)
		{
			array[j] = array2[j - length];
		}
		byte b = (byte)ushort_0;
		byte b2 = (byte)(ushort_0 >> 8);
		for (int k = 0; k < 16; k += 2)
		{
			array[k] ^= b;
			array[k + 1] ^= b2;
		}
		for (int l = 0; l < array.Length; l++)
		{
			byte b3 = (byte)(array[l] >> 6);
			array[l] <<= 2;
			array[l] |= b3;
		}
		return array;
	}
}
