using System.Runtime.CompilerServices;

namespace ns45;

internal class Class1166
{
	internal ushort ushort_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	private Class1168 class1168_0;

	internal Class1166()
	{
	}

	internal Class1166(int int_0)
	{
		ushort_1 = (ushort)int_0;
		ushort_0 = 0;
		ushort_2 = ushort.MaxValue;
	}

	internal Class1166(int int_0, int int_1)
	{
		ushort_1 = ushort.MaxValue;
		ushort_2 = ushort.MaxValue;
		Class1167 class1167_ = new Class1167
		{
			ushort_0 = (ushort)int_0,
			ushort_1 = (ushort)int_1
		};
		method_1().Add(class1167_);
	}

	internal Class1168 method_0()
	{
		return class1168_0;
	}

	[SpecialName]
	internal Class1168 method_1()
	{
		if (class1168_0 == null)
		{
			class1168_0 = new Class1168();
		}
		return class1168_0;
	}
}
