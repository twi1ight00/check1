using System;
using System.Globalization;
using System.Text;
using ns2;

namespace ns14;

internal class Class503 : Class495
{
	private static readonly DateTime dateTime_0 = DateTime.MaxValue.AddMilliseconds(-500.0);

	private CultureInfo cultureInfo_0;

	private string string_0;

	internal Class503(Class509 class509_1, string string_1, bool bool_0)
		: base(class509_1, string_1)
	{
		switch (class509_0.method_2())
		{
		case 0:
			cultureInfo_0 = class509_0.method_0().CultureInfo;
			string_0 = method_8(string_1, bool_0);
			return;
		case -2048:
			cultureInfo_0 = class509_0.method_0().CultureInfo;
			string_0 = cultureInfo_0.DateTimeFormat.LongDatePattern;
			return;
		case -3072:
			cultureInfo_0 = class509_0.method_0().CultureInfo;
			string_0 = cultureInfo_0.DateTimeFormat.LongTimePattern;
			return;
		}
		string_0 = method_8(string_1, bool_0);
		cultureInfo_0 = Class519.smethod_5(class509_0.method_2());
		if (method_6(256))
		{
			if (Class519.smethod_2(17, class509_0.method_2()))
			{
				cultureInfo_0.DateTimeFormat.Calendar = new JapaneseCalendar();
			}
			else if (Class519.smethod_2(18, class509_0.method_2()))
			{
				cultureInfo_0.DateTimeFormat.Calendar = new KoreanCalendar();
			}
		}
	}

	protected override void vmethod_0(char[] char_0, int int_0, int int_1)
	{
	}

	private string method_8(string string_1, bool bool_0)
	{
		char[] array = string_1.ToCharArray();
		StringBuilder stringBuilder = new StringBuilder(array.Length);
		if (bool_0)
		{
			method_4(array, 0, array.Length, stringBuilder);
		}
		else
		{
			for (int num = 0; num < array.Length; num = vmethod_1(array, num, array.Length, stringBuilder))
			{
			}
		}
		return stringBuilder.ToString();
	}

	internal override Class518 Format(Class515 class515_0, DateTime dateTime_1, double double_0, bool bool_0)
	{
		if (bool_0)
		{
			if (dateTime_1.CompareTo(dateTime_0) > 0)
			{
				Class518 @class = base.Format(class515_0, dateTime_1, double_0, bool_0);
				if (@class.method_5() == Enum136.const_7)
				{
					@class.method_3(class515_0.method_2());
				}
				return @class;
			}
			dateTime_1 = dateTime_1.AddMilliseconds(500.0);
		}
		Class518 class2 = base.Format(class515_0, dateTime_1, double_0, bool_0);
		if (class2.method_5() != Enum136.const_7)
		{
			return class2;
		}
		class2.method_0(Enum136.const_3, dateTime_1.ToString(string_0, cultureInfo_0));
		return class2;
	}
}
