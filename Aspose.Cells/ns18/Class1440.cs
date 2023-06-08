using System.Runtime.CompilerServices;
using ns40;

namespace ns18;

internal class Class1440
{
	private int int_0;

	private Class1442 class1442_0;

	private Class1444 class1444_0;

	internal Class961 Pages => class1442_0.Pages;

	public Class1440(Class1442 class1442_1)
	{
		class1442_0 = class1442_1;
		class1444_0 = new Class1444(this);
	}

	internal int method_0()
	{
		return ++int_0;
	}

	[SpecialName]
	internal Class1448 method_1()
	{
		return class1442_0.method_7();
	}

	[SpecialName]
	internal Class1451 method_2()
	{
		return class1442_0.method_9();
	}

	[SpecialName]
	internal Class1438 method_3()
	{
		return class1442_0.method_10();
	}

	[SpecialName]
	internal Class949 method_4()
	{
		return class1442_0.method_11();
	}

	[SpecialName]
	internal Class946 method_5()
	{
		return class1442_0.method_12();
	}

	[SpecialName]
	internal Class1444 method_6()
	{
		return class1444_0;
	}

	[SpecialName]
	internal Class945 method_7()
	{
		return class1442_0.method_16();
	}
}
