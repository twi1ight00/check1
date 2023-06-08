using System;
using System.Collections.Generic;
using System.IO;
using ns33;
using ns4;

namespace ns45;

internal class Class1100 : Class1099
{
	private static readonly int int_3 = 109;

	private int int_4;

	private Class1101 class1101_0;

	private int int_5 = -2;

	public void method_3(Class1101 sat)
	{
		class1101_0 = sat;
	}

	public override int[] vmethod_0()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < int_0.Length; i++)
		{
			if (i - int_3 + 1 <= 0 || (i - int_3 + 1) % 128 != 0)
			{
				list.Add(int_0[i]);
			}
		}
		return list.ToArray();
	}

	public int method_4()
	{
		return int_5;
	}

	public Class1100(int sectorSize)
		: this(0, sectorSize)
	{
	}

	public Class1100(int totalNumberOfSectors, int sectorSize)
	{
		int_1 = int_3;
		if (totalNumberOfSectors > 0)
		{
			int_0 = new int[int_3 + sectorSize / 4 * totalNumberOfSectors];
		}
		else
		{
			int_0 = new int[int_3];
		}
		Class1165.smethod_16(int_0, -2);
		int_4 = 0;
	}

	public void method_5(Stream inputStream)
	{
		int i;
		for (i = 0; i < int_3; i++)
		{
			BinaryReader binaryReader = new BinaryReader(inputStream);
			int_0[i] = binaryReader.ReadInt32();
		}
		if (i == int_3)
		{
			int_2 = int_3;
		}
		else
		{
			method_7();
		}
	}

	public void method_6(int sid)
	{
		if ((int_4 > int_0.Length - 1 && int_0.Length == int_3) || (int_4 > int_0.Length - 2 && int_0.Length != int_3))
		{
			if (int_0.Length == int_3)
			{
				method_2();
				int_5 = class1101_0.method_7();
			}
			else
			{
				method_2();
				int_0[int_4] = class1101_0.method_7();
				int_4++;
			}
		}
		int_0[int_4] = sid;
		int_4++;
	}

	public override int vmethod_1()
	{
		method_7();
		return int_2;
	}

	private void method_7()
	{
		int_2 = -1;
		while (int_0.Length > ++int_2 && int_0[int_2] >= 0)
		{
		}
	}

	private void method_8()
	{
		for (int i = 109; i < int_0.Length; i++)
		{
			if (int_0[i] == 0)
			{
				int_0[i] = -1;
			}
		}
		if (int_0.Length > 109)
		{
			int_0[int_0.Length - 1] = -2;
		}
	}

	public void method_9(Interface36 reader, int firstSID)
	{
		int num = firstSID;
		while (num > -1 && int_1 < int_0.Length)
		{
			Class1111 @class = reader.imethod_1(num);
			int val = @class.method_0().Length;
			val = Math.Min(val, (int_0.Length - int_1) * 4);
			method_0(@class, val);
			num = method_10(@class);
		}
		int_1 = int_3;
		method_8();
		method_7();
	}

	private int method_10(Class1111 sector)
	{
		byte[] array = new byte[4];
		Array.Copy(sector.method_0(), sector.method_0().Length - 4, array, 0, 4);
		return Class1162.smethod_7(array);
	}

	public override List<Class1111> imethod_1(int sectorSize)
	{
		int num = vmethod_1();
		List<Class1111> list = new List<Class1111>();
		if (num > int_3)
		{
			int num2 = int_3;
			while (num2 < num)
			{
				byte[] array = new byte[sectorSize];
				Class1165.smethod_15(array, byte.MaxValue);
				int num3 = 0;
				int num4 = ((num2 * 4 + sectorSize < num * 4) ? sectorSize : ((num - num2) * 4));
				while (num3 < num4)
				{
					array[num3] = (byte)((uint)int_0[num2] & 0xFFu);
					array[num3 + 1] = (byte)((uint)(int_0[num2] >> 8) & 0xFFu);
					array[num3 + 2] = (byte)((uint)(int_0[num2] >> 16) & 0xFFu);
					array[num3 + 3] = (byte)((uint)(int_0[num2] >> 24) & 0xFFu);
					num3 += 4;
					num2++;
				}
				list.Add(new Class1111(array));
			}
			return list;
		}
		return new List<Class1111>();
	}

	public override int imethod_0(int sectorSize)
	{
		return (int)Math.Ceiling((double)(int_0.Length - int_3) * 4.0 / (double)sectorSize);
	}

	public byte[] method_11()
	{
		byte[] array = new byte[int_3 * 4];
		Class1165.smethod_15(array, byte.MaxValue);
		for (int i = 0; i < vmethod_1() && i < int_3; i++)
		{
			array[4 * i] = (byte)((uint)int_0[i] & 0xFFu);
			array[4 * i + 1] = (byte)((uint)(int_0[i] >> 8) & 0xFFu);
			array[4 * i + 2] = (byte)((uint)(int_0[i] >> 16) & 0xFFu);
			array[4 * i + 3] = (byte)((uint)(int_0[i] >> 24) & 0xFFu);
		}
		return array;
	}
}
