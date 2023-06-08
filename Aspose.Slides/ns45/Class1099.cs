using System;
using System.Collections.Generic;
using ns33;
using ns4;

namespace ns45;

internal abstract class Class1099 : Interface35
{
	protected int[] int_0;

	protected int int_1;

	protected int int_2;

	public virtual int[] vmethod_0()
	{
		return int_0;
	}

	protected void method_0(Class1111 sector, int len)
	{
		byte[] array = new byte[4];
		int num = 0;
		byte[] sourceArray = sector.method_0();
		while (num < len)
		{
			Array.Copy(sourceArray, num, array, 0, 4);
			num += 4;
			int_0[int_1] = Class1162.smethod_7(array);
			int_1++;
		}
	}

	public Class1099()
	{
		int_0 = new int[0];
	}

	public virtual int vmethod_1()
	{
		return int_0.Length;
	}

	public int[] method_1(int firstSID)
	{
		if (int_0.Length == 0)
		{
			return new int[0];
		}
		bool flag = false;
		List<int> list = new List<int>();
		int num = firstSID;
		while (!flag)
		{
			list.Add(num);
			if (int_0[num] != -1 && int_0[num] != -4 && int_0[num] != -3)
			{
				num = int_0[num];
				if (num == -2 || int_0.Length < num)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		return list.ToArray();
	}

	protected void method_2()
	{
		if (int_0 == null)
		{
			int_0 = new int[128];
			return;
		}
		int[] array = new int[int_0.Length + 128];
		Class1165.smethod_16(array, -1);
		Array.Copy(int_0, 0, array, 0, int_0.Length);
		int_0 = array;
	}

	public virtual int imethod_0(int sectorSize)
	{
		return (int)Math.Ceiling((double)int_0.Length * 4.0 / (double)sectorSize);
	}

	public virtual List<Class1111> imethod_1(int sectorSize)
	{
		List<Class1111> list = new List<Class1111>();
		int num = 0;
		while (num < vmethod_1())
		{
			byte[] array = new byte[sectorSize];
			Class1165.smethod_15(array, byte.MaxValue);
			int num2 = 0;
			int num3 = ((num * 4 + sectorSize < vmethod_1() * 4) ? sectorSize : ((vmethod_1() - num) * 4));
			while (num2 < num3)
			{
				array[num2] = (byte)((uint)int_0[num] & 0xFFu);
				array[num2 + 1] = (byte)((uint)(int_0[num] >> 8) & 0xFFu);
				array[num2 + 2] = (byte)((uint)(int_0[num] >> 16) & 0xFFu);
				array[num2 + 3] = (byte)((uint)(int_0[num] >> 24) & 0xFFu);
				num2 += 4;
				num++;
			}
			list.Add(new Class1111(array));
		}
		return list;
	}
}
