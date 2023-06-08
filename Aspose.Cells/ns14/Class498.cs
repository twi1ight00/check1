using System;
using System.Text;

namespace ns14;

internal class Class498 : Class496
{
	private readonly Class503 class503_0;

	internal Class498(Class509 class509_1, string string_2, string string_3)
		: base(class509_1, string_2, string_3)
	{
		class503_0 = new Class503(class509_1, "MMM", bool_0: false);
	}

	protected override void vmethod_5(Class515 class515_0, DateTime dateTime_0, double double_0, StringBuilder stringBuilder_0)
	{
		Class518 @class = class503_0.Format(class515_0, dateTime_0, double_0, bool_0: false);
		char[] value = @class.Value;
		if (value != null && value.Length > 0)
		{
			stringBuilder_0.Append(value[0]);
			return;
		}
		switch (dateTime_0.Month)
		{
		case 2:
			stringBuilder_0.Append('F');
			break;
		case 3:
		case 5:
			stringBuilder_0.Append('M');
			break;
		case 1:
		case 6:
		case 7:
			stringBuilder_0.Append('J');
			break;
		case 4:
		case 8:
			stringBuilder_0.Append('A');
			break;
		case 9:
			stringBuilder_0.Append('S');
			break;
		case 10:
			stringBuilder_0.Append('O');
			break;
		case 11:
			stringBuilder_0.Append('N');
			break;
		case 12:
			stringBuilder_0.Append('D');
			break;
		}
	}
}
