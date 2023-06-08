using System.Runtime.CompilerServices;

namespace ns52;

internal class Class1700
{
	private int int_0;

	private int int_1;

	private ushort ushort_0;

	internal int Length => 8;

	internal Class1700(int int_2)
	{
		ushort_0 = (ushort)int_2;
		int_0 = 1;
		int_1 = int_2 * 1024 + 1024;
	}

	internal Class1700(int int_2, int int_3)
	{
		ushort_0 = (ushort)int_2;
		int_0 = 1;
		int_1 = int_3;
	}

	internal void Copy(Class1700 class1700_0)
	{
		ushort_0 = class1700_0.ushort_0;
		int_1 = class1700_0.int_1;
		int_0 = class1700_0.int_0;
	}

	[SpecialName]
	internal ushort method_0()
	{
		return ushort_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_2(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_4(int int_2)
	{
		int_1 = int_2;
	}

	internal void AddShape(Class1703 class1703_0, int int_2)
	{
		int_0 += int_2;
		int_1 += int_2;
		int num = class1703_0.method_2().AddShape(ushort_0, int_2);
		if (num != -1)
		{
			int_1 = num;
		}
	}
}
