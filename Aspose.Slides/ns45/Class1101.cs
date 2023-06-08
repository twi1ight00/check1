using System;
using System.Collections.Generic;
using ns33;

namespace ns45;

internal class Class1101 : Class1099
{
	private int int_3;

	private int int_4;

	private Class1100 class1100_0;

	public Class1101(int sectorSize)
	{
		int_3 = sectorSize;
	}

	public void method_3(Class1100 msat, Interface36 reader)
	{
		int[] array = msat.vmethod_0();
		int_0 = new int[(int)reader.imethod_0().method_16() * int_3 / 4];
		Class1165.smethod_16(int_0, -1);
		for (int i = 0; array.Length != i && array[i] != -1; i++)
		{
			Class1111 @class = reader.imethod_1(array[i]);
			method_0(@class, @class.method_0().Length);
		}
	}

	public int method_4(int firstSID)
	{
		int[] array = null;
		array = ((firstSID < 0) ? new int[0] : method_1(firstSID));
		int num = method_6();
		if (array.Length != 0)
		{
			int_0[array[array.Length - 1]] = num;
		}
		int_0[num] = -2;
		return num;
	}

	public int method_5(int numberOfSectors)
	{
		int num = method_4(-5);
		int result = num;
		for (int i = 1; i < numberOfSectors; i++)
		{
			num = method_4(num);
		}
		return result;
	}

	private int method_6()
	{
		if (int_4 + 1 > int_0.Length - 1)
		{
			method_2();
			while (int_0[int_4] != -1)
			{
				int_4++;
			}
			int_0[int_4] = -3;
			class1100_0.method_6(int_4);
		}
		while (int_0[int_4] != -1)
		{
			int_4++;
		}
		return int_4;
	}

	public override int imethod_0(int sectorSize)
	{
		if (int_0 != null)
		{
			return (int)Math.Ceiling((double)int_0.Length * 4.0 / (double)sectorSize);
		}
		return 0;
	}

	public int method_7()
	{
		int num = method_6();
		int_0[num] = -4;
		return num;
	}

	public void method_8(Class1100 masterSAT)
	{
		class1100_0 = masterSAT;
	}

	public int[] method_9()
	{
		int num = vmethod_1();
		List<int> list = new List<int>();
		for (int i = 0; i < num; i++)
		{
			if (int_0[i] == -4)
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}
}
