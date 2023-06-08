using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1449
{
	private Class1440 class1440_0;

	private Class959 class959_0;

	private Class959 class959_1;

	internal Class1449(Class1440 class1440_1)
	{
		class1440_0 = class1440_1;
		class959_0 = new Class959(class1440_0, "Root", -1, null, bool_1: true);
		class959_1 = class959_0;
	}

	internal void method_0(string string_0, int int_0, Class1441 class1441_0, bool bool_0)
	{
		Class959 @class = new Class959(class1440_0, string_0, int_0, class1441_0, bool_0);
		if (@class.int_1 > class959_1.int_1)
		{
			class959_1.method_4(@class);
		}
		else if (@class.int_1 < class959_1.int_1)
		{
			while (class959_1.int_1 >= @class.int_1)
			{
				class959_1 = class959_1.class959_0;
			}
			class959_1.method_4(@class);
		}
		else
		{
			class959_1.class959_0.method_4(@class);
		}
		class959_1 = @class;
	}

	internal void method_1(Class1447 class1447_0)
	{
		class1447_0.method_24(class959_0);
		class1447_0.method_9();
		class1447_0.method_11("/Type", "/Outlines");
		if (class959_0.class959_3 != null)
		{
			class1447_0.method_11("/First", class959_0.class959_3.method_1());
		}
		if (class959_0.class959_4 != null)
		{
			class1447_0.method_11("/Last", class959_0.class959_4.method_1());
		}
		class1447_0.method_10();
		class1447_0.method_25();
		for (Class959 @class = class959_0.class959_3; @class != null; @class = @class.class959_2)
		{
			@class.vmethod_1(class1447_0);
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		return class959_0.class959_3 == null;
	}

	[SpecialName]
	internal string method_3()
	{
		return class959_0.method_1();
	}
}
