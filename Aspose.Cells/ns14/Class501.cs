using System;
using System.Text;
using ns22;

namespace ns14;

internal class Class501 : Class496
{
	private readonly Class503 class503_0;

	private readonly bool bool_0;

	internal Class501(Class509 class509_1, string string_2, string string_3, bool bool_1)
		: base(class509_1, string_2, string_3)
	{
		class503_0 = new Class503(class509_1, bool_1 ? Class1180.smethod_4() : Class1180.smethod_3(), bool_0: false);
		if (!bool_1 && Class519.smethod_2(2052, (class509_1.method_2() == 0) ? class509_1.method_0().method_3() : class509_1.method_2()))
		{
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
		}
	}

	protected override void vmethod_5(Class515 class515_0, DateTime dateTime_0, double double_0, StringBuilder stringBuilder_0)
	{
		Class518 @class = class503_0.Format(class515_0, dateTime_0, double_0, bool_0: false);
		char[] value = @class.Value;
		if (value != null && value.Length >= 1)
		{
			if (bool_0)
			{
				stringBuilder_0.Append(value[value.Length - 1]);
			}
			else
			{
				stringBuilder_0.Append(value);
			}
		}
	}
}
