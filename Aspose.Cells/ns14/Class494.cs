using System;
using System.Globalization;
using System.Text;
using ns2;
using ns22;

namespace ns14;

internal class Class494 : Class488
{
	private CultureInfo cultureInfo_0;

	private string string_0;

	private int int_0;

	private char char_0;

	private string string_1;

	internal Class494(Class509 class509_1, string string_2)
		: base(class509_1, string_2)
	{
		method_5(class509_0.method_0());
	}

	protected override void vmethod_0(char[] char_1, int int_1, int int_2)
	{
		int_0 = -1;
		StringBuilder stringBuilder = new StringBuilder(int_2 - int_1 + 1);
		method_3(char_1, int_1, int_2, stringBuilder);
		string_0 = stringBuilder.ToString();
		if (int_0 > 1)
		{
			if (class511_0.method_4() > -1)
			{
				string_1 = "#" + string_0.Substring(string_0.IndexOf('.'));
			}
			else
			{
				string_1 = "#" + string_0.Substring(string_0.IndexOf('E'));
			}
		}
	}

	protected override int vmethod_1(char[] char_1, int int_1, int int_2, StringBuilder stringBuilder_0)
	{
		switch (char_1[int_1])
		{
		default:
			int_1 = base.vmethod_1(char_1, int_1, int_2, stringBuilder_0);
			break;
		case 'E':
		case 'e':
			if (int_0 < 0)
			{
				if (int_0 == -1)
				{
					int_0 = stringBuilder_0.Length;
				}
				else
				{
					int_0 = -int_0 - 2;
				}
				stringBuilder_0.Append('E');
				int_1++;
			}
			else
			{
				int_1 = base.vmethod_1(char_1, int_1, int_2, stringBuilder_0);
			}
			break;
		case '.':
			if (int_0 == -1)
			{
				int_0 = -stringBuilder_0.Length - 2;
			}
			int_1 = base.vmethod_1(char_1, int_1, int_2, stringBuilder_0);
			break;
		}
		return int_1;
	}

	protected override double vmethod_3(double double_0)
	{
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		return Class1024.smethod_0(double_0, class511_0.method_2());
	}

	internal override void vmethod_4(Class515 class515_0, double double_0, Class518 class518_1)
	{
		string text = null;
		if (int_0 > 1 && double_0 != 0.0)
		{
			int value = (int)Math.Log10(Math.Abs(double_0));
			if (Math.Abs(value) <= int_0)
			{
				text = double_0.ToString(string_1, cultureInfo_0);
			}
		}
		if (text == null)
		{
			text = double_0.ToString(string_0, cultureInfo_0);
		}
		if (class511_0.method_4() > -1 && text.IndexOf(char_0) < 0)
		{
			if (int_0 > -1)
			{
				int num = text.IndexOf('E');
				text = text.Substring(0, num) + char_0 + text.Substring(num);
			}
			else
			{
				text += char_0;
			}
		}
		class518_1.method_0(Enum136.const_2, text);
	}

	private void method_5(Class516 class516_0)
	{
		cultureInfo_0 = class516_0.CultureInfo;
		char_0 = class516_0.method_4().method_2();
	}
}
