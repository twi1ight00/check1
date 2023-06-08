using System;
using Aspose.Cells;
using ns10;
using ns16;
using ns2;

namespace ns9;

internal class Class392 : Class316
{
	internal Class392()
	{
		int_0 = 153;
	}

	internal void method_6(Workbook workbook_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		if (workbook_0.class1558_0 != null)
		{
			Class1364 class1364_ = workbook_0.class1558_0.class1364_0;
			num = ((class1364_.string_0 == null) ? 124226 : Class1618.smethod_87(class1364_.string_0));
			if (class1364_.string_1 != null)
			{
				num2 = Class1618.smethod_87(class1364_.string_1);
			}
			if (class1364_.string_2 != null)
			{
				num3 = Class1618.smethod_87(class1364_.string_2);
			}
			if (class1364_.string_3 != null && Class1677.smethod_19(class1364_.string_3))
			{
				num4 = Class1618.smethod_87(class1364_.string_3);
			}
			if (class1364_.string_4 != null)
			{
				num5 = Class1618.smethod_87(class1364_.string_4);
			}
		}
		else
		{
			num = 124226;
		}
		int num6 = 8;
		num6 = ((workbook_0.Worksheets.CodeName != null) ? (num6 + (4 + workbook_0.Worksheets.CodeName.Length * 2)) : (num6 + 4));
		byte_0 = new byte[num6];
		byte_0[0] = 32;
		if (workbook_0.Settings.Date1904)
		{
			byte_0[0] |= 1;
		}
		if (num2 == 1)
		{
			byte_0[0] |= 8;
		}
		if (num3 == 1)
		{
			byte_0[1] |= 4;
		}
		if (num5 == 1)
		{
			byte_0[1] |= 8;
		}
		switch (num4)
		{
		case 2:
			byte_0[1] |= 1;
			break;
		case 1:
			byte_0[0] |= 128;
			break;
		}
		byte_0[2] = 1;
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 4, 4);
		if (workbook_0.Worksheets.CodeName != null)
		{
			int num7 = 8;
			Class1217.smethod_7(byte_0, ref num7, workbook_0.Worksheets.CodeName);
		}
	}
}
