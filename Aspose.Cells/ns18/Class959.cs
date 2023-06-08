namespace ns18;

internal class Class959 : Class938
{
	internal string string_1;

	internal int int_1;

	internal Class1441 class1441_0;

	internal Class959 class959_0;

	internal Class959 class959_1;

	internal Class959 class959_2;

	internal Class959 class959_3;

	internal Class959 class959_4;

	internal bool bool_0;

	internal Class959(Class1440 class1440_1, string string_2, int int_2, Class1441 class1441_1, bool bool_1)
		: base(class1440_1)
	{
		string_1 = string_2;
		int_1 = int_2;
		class1441_0 = class1441_1;
		bool_0 = bool_1;
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		class1447_0.method_13("/Title", string_1);
		class1447_0.method_11("/Parent", class959_0.method_1());
		if (class959_1 != null)
		{
			class1447_0.method_11("/Prev", class959_1.method_1());
		}
		if (class959_2 != null)
		{
			class1447_0.method_11("/Next", class959_2.method_1());
		}
		if (class959_3 != null)
		{
			class1447_0.method_11("/First", class959_3.method_1());
		}
		if (class959_4 != null)
		{
			class1447_0.method_11("/Last", class959_4.method_1());
		}
		if (class959_3 != null)
		{
			int num = method_5();
			class1447_0.method_16("/Count", num);
		}
		class1447_0.Write("/Dest");
		class1441_0.method_0(class1447_0);
		class1447_0.method_10();
		class1447_0.method_25();
		for (Class959 @class = class959_3; @class != null; @class = @class.class959_2)
		{
			@class.vmethod_1(class1447_0);
		}
	}

	internal void method_4(Class959 class959_5)
	{
		if (class959_3 == null)
		{
			class959_3 = class959_5;
		}
		else
		{
			class959_4.class959_2 = class959_5;
			class959_5.class959_1 = class959_4;
		}
		class959_4 = class959_5;
		class959_5.class959_0 = this;
	}

	private int method_5()
	{
		int num = 0;
		for (Class959 @class = class959_3; @class != null; @class = @class.class959_2)
		{
			num++;
		}
		if (bool_0)
		{
			return num;
		}
		return -num;
	}
}
