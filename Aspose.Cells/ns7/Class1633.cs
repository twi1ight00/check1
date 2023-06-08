using System.Runtime.CompilerServices;

namespace ns7;

internal class Class1633
{
	private Class1632 class1632_0;

	private int int_0 = 25;

	internal Class1633(Class1632 class1632_1)
	{
		class1632_0 = class1632_1;
	}

	internal void Copy(Class1633 class1633_0)
	{
		int_0 = class1633_0.int_0;
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_1)
	{
		int_0 = int_1;
		class1632_0.method_1(bool_6: false);
	}
}
