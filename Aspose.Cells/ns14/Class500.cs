using System;
using System.Text;

namespace ns14;

internal class Class500 : Class496
{
	private readonly int int_0;

	internal Class500(Class509 class509_1, string string_2, string string_3, int int_1)
		: base(class509_1, string_2, string_3)
	{
		int_0 = int_1;
	}

	protected override void vmethod_5(Class515 class515_0, DateTime dateTime_0, double double_0, StringBuilder stringBuilder_0)
	{
		int num = dateTime_0.Millisecond;
		switch (int_0)
		{
		case 1:
			num = (int)((float)num / 100f);
			break;
		case 2:
			num = (int)((float)num / 10f);
			break;
		}
		stringBuilder_0.Append(class509_0.method_0().CultureInfo.NumberFormat.NumberDecimalSeparator);
		string text = num.ToString();
		for (int i = text.Length; i < int_0; i++)
		{
			stringBuilder_0.Append('0');
		}
		stringBuilder_0.Append(text);
	}
}
