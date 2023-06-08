using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns234;

namespace ns271;

internal class Class6640
{
	private const short short_0 = 10;

	private const short short_1 = 11;

	private const short short_2 = 12;

	private const short short_3 = 13;

	private const short short_4 = 14;

	private const short short_5 = 15;

	private readonly byte[] byte_0;

	private int int_0;

	private readonly Hashtable hashtable_0;

	private List<double> list_0 = new List<double>();

	internal Class6640(byte[] data)
	{
		byte_0 = data;
		hashtable_0 = new Hashtable();
	}

	internal Hashtable method_0()
	{
		while (int_0 < byte_0.Length)
		{
			method_1();
		}
		return hashtable_0;
	}

	private void method_1()
	{
		byte[] array = new byte[5]
		{
			ReadByte(),
			0,
			0,
			0,
			0
		};
		if (array[0] >= 0 && array[0] <= 21)
		{
			if (array[0] == 12)
			{
				hashtable_0.Add(1200 + ReadByte(), list_0);
			}
			else
			{
				hashtable_0.Add((int)array[0], list_0);
			}
			list_0 = new List<double>();
			return;
		}
		if (array[0] == 30)
		{
			list_0.Add(method_2());
			return;
		}
		if (array[0] >= 32 && array[0] <= 246)
		{
			list_0.Add(array[0] - 139);
			return;
		}
		array[1] = ReadByte();
		if (array[0] >= 247 && array[0] <= 250)
		{
			list_0.Add((array[0] - 247) * 256 + array[1] + 108);
			return;
		}
		if (array[0] >= 251 && array[0] <= 254)
		{
			list_0.Add(-1 * (array[0] - 251) * 256 - array[1] - 108);
			return;
		}
		array[2] = ReadByte();
		if (array[0] == 28)
		{
			list_0.Add((short)((array[1] << 8) | array[2]));
			return;
		}
		array[3] = ReadByte();
		array[4] = ReadByte();
		if (array[0] != 29)
		{
			throw new ArgumentException("DICT operand does not fall in either of acceptable values.");
		}
		list_0.Add((array[1] << 24) | (array[2] << 16) | (array[3] << 8) | array[4]);
	}

	private double method_2()
	{
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder();
		while (!flag)
		{
			int num = ReadByte();
			int[] array = new int[2]
			{
				(num & 0xF0) >> 4,
				num & 0xF
			};
			for (int i = 0; i < 2; i++)
			{
				if (array[i] >= 0 && array[i] <= 9)
				{
					stringBuilder.Append(Class6159.smethod_24(array[i]));
					continue;
				}
				switch (array[i])
				{
				case 10:
					stringBuilder.Append(".");
					break;
				case 11:
					stringBuilder.Append("E");
					break;
				case 12:
					stringBuilder.Append("E-");
					break;
				case 14:
					stringBuilder.Append("-");
					break;
				case 15:
					flag = true;
					break;
				case 13:
					throw new ArgumentException("Reserved nibble value.");
				}
			}
		}
		return Class6159.smethod_8(stringBuilder.ToString());
	}

	private byte ReadByte()
	{
		return byte_0[int_0++];
	}
}
