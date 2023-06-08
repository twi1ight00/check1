using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns14;

internal class Class499 : Class496
{
	private readonly double double_0;

	private readonly int int_0;

	internal Class499(Class509 class509_1, string string_2, string string_3, int int_1, int int_2)
		: base(class509_1, string_2, string_3)
	{
		int_0 = int_2;
		switch (int_1)
		{
		default:
			double_0 = 1.0;
			break;
		case 0:
			double_0 = 24.0;
			break;
		case 1:
			double_0 = 1440.0;
			break;
		case 2:
			double_0 = 86400.0;
			break;
		}
	}

	[SpecialName]
	public override bool vmethod_3()
	{
		return true;
	}

	[SpecialName]
	public override bool vmethod_4()
	{
		return false;
	}

	protected override void vmethod_5(Class515 class515_0, DateTime dateTime_0, double double_1, StringBuilder stringBuilder_0)
	{
		int num = ((!(double_0 > 72000.0)) ? ((int)(Math.Round(double_1 * 86400000.0, 0) / 86400000.0 * double_0)) : ((!(double_1 < 0.0)) ? ((int)(double_1 * double_0 + 0.5)) : ((int)(double_1 * double_0 - 0.5))));
		string text = Math.Abs(num).ToString();
		if (num < 0)
		{
			stringBuilder_0.Append('-');
		}
		for (int i = text.Length; i < int_0; i++)
		{
			stringBuilder_0.Append('0');
		}
		stringBuilder_0.Append(text);
	}
}
