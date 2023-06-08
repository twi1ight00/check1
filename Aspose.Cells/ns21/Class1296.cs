using System.Runtime.CompilerServices;

namespace ns21;

internal class Class1296
{
	private Enum189 enum189_0;

	internal int int_0;

	internal int int_1;

	internal Class1294 class1294_0;

	internal Class1296()
	{
		enum189_0 = Enum189.const_46;
		int_0 = 100000;
	}

	internal void Copy(Class1296 class1296_0)
	{
		enum189_0 = class1296_0.enum189_0;
		int_1 = class1296_0.int_1;
		int_0 = class1296_0.int_0;
		if (class1296_0.class1294_0 != null)
		{
			class1294_0 = new Class1294();
			class1294_0.Copy(class1296_0.class1294_0);
		}
	}

	[SpecialName]
	internal Enum189 method_0()
	{
		return enum189_0;
	}

	[SpecialName]
	internal void method_1(Enum189 enum189_1)
	{
		enum189_0 = enum189_1;
	}

	[SpecialName]
	internal Class1294 method_2()
	{
		if (class1294_0 == null)
		{
			class1294_0 = new Class1294();
		}
		return class1294_0;
	}
}
