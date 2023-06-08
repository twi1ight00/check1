using System.Collections;
using Aspose.Cells;
using ns2;

namespace ns16;

internal class Class1544
{
	internal string string_0;

	internal Font font_0;

	internal int int_0;

	internal Enum217 enum217_0 = Enum217.flag_3;

	internal static ArrayList smethod_0(Class1720 class1720_0, Font font_1, Workbook workbook_0)
	{
		string text = class1720_0.string_0;
		byte[] array = class1720_0.method_2();
		ArrayList arrayList = new ArrayList();
		int num = -1;
		int int_ = -1;
		int num2 = 0;
		int num4;
		while (true)
		{
			if (num2 < array.Length)
			{
				int num3 = Class1618.smethod_11(array, num2);
				num4 = Class1618.smethod_11(array, num2 + 2);
				if (num2 == 0 && num3 != 0)
				{
					if (num3 > text.Length)
					{
						break;
					}
					smethod_1(arrayList, text, 0, num3, font_1, workbook_0);
				}
				if (num != -1)
				{
					smethod_2(arrayList, text, num, num3, int_, workbook_0);
				}
				num = num3;
				int_ = num4;
				num2 += 4;
				continue;
			}
			if (num != -1 && num < text.Length)
			{
				smethod_2(arrayList, text, num, text.Length, int_, workbook_0);
			}
			return arrayList;
		}
		smethod_2(arrayList, text, 0, text.Length - 1, num4, workbook_0);
		return arrayList;
	}

	private static void smethod_1(ArrayList arrayList_0, string string_1, int int_1, int int_2, Font font_1, Workbook workbook_0)
	{
		if (int_2 >= int_1)
		{
			Class1544 @class = new Class1544();
			@class.string_0 = string_1.Substring(int_1, int_2 - int_1);
			@class.font_0 = font_1;
			arrayList_0.Add(@class);
		}
	}

	private static void smethod_2(ArrayList arrayList_0, string string_1, int int_1, int int_2, int int_3, Workbook workbook_0)
	{
		if (int_1 > int_2 || int_1 >= string_1.Length)
		{
			return;
		}
		if (int_2 > string_1.Length)
		{
			int_2 = string_1.Length;
		}
		Class1544 @class = new Class1544();
		@class.string_0 = string_1.Substring(int_1, int_2 - int_1);
		if (int_3 < 0)
		{
			@class.font_0 = null;
		}
		else
		{
			if (int_3 > 4)
			{
				int_3--;
			}
			if (int_3 >= workbook_0.Worksheets.method_52().Count)
			{
				@class.font_0 = (Font)workbook_0.Worksheets.method_52()[0];
			}
			else
			{
				@class.font_0 = (Font)workbook_0.Worksheets.method_52()[int_3];
			}
		}
		arrayList_0.Add(@class);
	}
}
