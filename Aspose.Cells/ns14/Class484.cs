using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;
using ns47;

namespace ns14;

internal class Class484
{
	private readonly bool bool_0;

	private readonly string string_0;

	private readonly int int_0;

	private readonly FontStyle fontStyle_0;

	private Class1460 class1460_0;

	internal string FontName => string_0;

	internal int FontSize => int_0;

	internal Class484(string string_1, int int_1, FontStyle fontStyle_1, bool bool_1, Class484 class484_0)
	{
		string_0 = string_1;
		int_0 = int_1;
		fontStyle_0 = fontStyle_1;
		bool_0 = bool_1;
		if (class484_0 != null && string_1 == class484_0.string_0 && fontStyle_1 == class484_0.fontStyle_0)
		{
			class1460_0 = class484_0.class1460_0;
		}
	}

	internal Class484(string string_1, int int_1, FontStyle fontStyle_1, Class1460 class1460_1)
	{
		string_0 = string_1;
		int_0 = int_1;
		fontStyle_0 = fontStyle_1;
		bool_0 = false;
		class1460_0 = class1460_1;
	}

	internal bool method_0(Class484 class484_0)
	{
		if (this != class484_0)
		{
			if (int_0 == class484_0.int_0 && fontStyle_0 == class484_0.fontStyle_0)
			{
				return string_0 == class484_0.string_0;
			}
			return false;
		}
		return true;
	}

	internal bool method_1(string string_1, int int_1, FontStyle fontStyle_1)
	{
		if (int_1 == int_0 && fontStyle_1 == fontStyle_0)
		{
			return string_1 == string_0;
		}
		return false;
	}

	internal int method_2(string string_1)
	{
		if (class1460_0 != null)
		{
			return Class1181.smethod_8(string_1, class1460_0, int_0);
		}
		if (bool_0)
		{
			class1460_0 = Class1181.smethod_7(string_0, fontStyle_0);
			return Class1181.smethod_8(string_1, class1460_0, int_0);
		}
		return Class1181.smethod_9(string_1, string_0, int_0, fontStyle_0);
	}

	internal float method_3(char char_0)
	{
		if (class1460_0 != null)
		{
			return Class1181.smethod_10(char_0, class1460_0, int_0);
		}
		if (bool_0)
		{
			class1460_0 = Class1181.smethod_7(string_0, fontStyle_0);
			return Class1181.smethod_10(char_0, class1460_0, int_0);
		}
		return Class1181.smethod_11(char_0, string_0, int_0, fontStyle_0);
	}

	[SpecialName]
	internal FontStyle method_4()
	{
		return fontStyle_0;
	}

	[SpecialName]
	internal Class1460 method_5()
	{
		return class1460_0;
	}
}
