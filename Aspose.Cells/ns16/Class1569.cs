using System.Drawing;

namespace ns16;

internal class Class1569
{
	internal string string_0 = "Office";

	internal Class928[] class928_0 = new Class928[12];

	internal Class1193 class1193_0 = new Class1193();

	internal Class1569(string string_1, Color[] color_0)
	{
		string_0 = string_1;
		class928_0 = new Class928[12];
		for (int i = 0; i < color_0.Length; i++)
		{
			Class928 @class = new Class928
			{
				Color = color_0[i]
			};
			class928_0[i] = @class;
			@class.string_0 = Class1618.smethod_160(i);
		}
	}

	internal void Copy(Class1569 class1569_0)
	{
		string_0 = class1569_0.string_0;
		class928_0 = new Class928[12];
		for (int i = 0; i < class1569_0.class928_0.Length; i++)
		{
			Class928 @class = new Class928();
			@class.string_0 = class1569_0.class928_0[i].string_0;
			@class.Color = class1569_0.class928_0[i].Color;
			class928_0[i] = @class;
		}
	}

	internal bool method_0()
	{
		if (string.Compare(string_0, "Office", ignoreCase: true) != 0)
		{
			return true;
		}
		return false;
	}

	internal Class1569()
	{
		method_1();
	}

	internal Color GetThemeColor(int int_0)
	{
		if (int_0 >= 0 && int_0 <= class928_0.Length - 1)
		{
			return class928_0[int_0].Color;
		}
		return Color.Empty;
	}

	internal void method_1()
	{
		for (int i = 0; i < 12; i++)
		{
			Class928 @class = class928_0[i];
			if (@class == null)
			{
				class928_0[i] = method_2(i);
			}
		}
	}

	private Class928 method_2(int int_0)
	{
		switch (int_0)
		{
		default:
			return method_3("lt1", "000000");
		case 0:
		{
			Class928 class2 = new Class928();
			class2.string_0 = "lt1";
			class2.Color = Class1618.smethod_63("ffffff");
			class2.method_1(bool_1: true);
			class2.string_1 = "window";
			return class2;
		}
		case 1:
		{
			Class928 @class = new Class928();
			@class.string_0 = "dk1";
			@class.Color = Class1618.smethod_63("000000");
			@class.method_1(bool_1: true);
			@class.string_1 = "windowText";
			return @class;
		}
		case 2:
			return method_3("lt2", "EEECE1");
		case 3:
			return method_3("dk2", "1F497D");
		case 4:
			return method_3("accent1", "4F81BD");
		case 5:
			return method_3("accent2", "C0504D");
		case 6:
			return method_3("accent3", "9BBB59");
		case 7:
			return method_3("accent4", "8064A2");
		case 8:
			return method_3("accent5", "4BACC6");
		case 9:
			return method_3("accent6", "F79646");
		case 10:
			return method_3("hlink", "0000FF");
		case 11:
			return method_3("folHlink", "800080");
		}
	}

	private Class928 method_3(string string_1, string string_2)
	{
		Class928 @class = new Class928();
		@class.string_0 = string_1;
		@class.Color = Class1618.smethod_63(string_2);
		return @class;
	}
}
