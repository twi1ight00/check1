using System;
using System.Text;

namespace ns14;

internal class Class497 : Class496
{
	private string string_2;

	private string string_3;

	internal Class497(Class509 class509_1, string string_4, string string_5, string string_6, string string_7)
		: base(class509_1, string_4, string_5)
	{
		string_2 = string_6;
		string_3 = string_7;
	}

	protected override void vmethod_5(Class515 class515_0, DateTime dateTime_0, double double_0, StringBuilder stringBuilder_0)
	{
		if (dateTime_0.Hour < 12)
		{
			stringBuilder_0.Append(string_2);
		}
		else
		{
			stringBuilder_0.Append(string_3);
		}
	}
}
