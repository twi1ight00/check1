using System;
using Aspose.Cells;
using ns10;
using ns2;

namespace ns9;

internal class Class350 : Class316
{
	internal Class350()
	{
		int_0 = 637;
	}

	internal void method_6(Class1737 class1737_0, Workbook workbook_0)
	{
		int num = 0;
		num = ((class1737_0.method_12() == null) ? 1 : class1737_0.method_12().Count);
		if (class1737_0.Text != null)
		{
			byte_0 = new byte[5 + class1737_0.Text.Length * 2 + 4 + num * 4];
		}
		byte_0[0] = 1;
		int num2 = 1;
		Class1217.smethod_7(byte_0, ref num2, class1737_0.Text);
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, num2, 4);
		num2 += 4;
		if (num == 1)
		{
			int int_ = class1737_0.method_8();
			Array.Copy(BitConverter.GetBytes(0), 0, byte_0, num2, 2);
			num2 += 2;
			int value = method_7(int_, workbook_0.Worksheets);
			Array.Copy(BitConverter.GetBytes(value), 0, byte_0, num2, 2);
			num2 += 2;
			return;
		}
		for (int i = 0; i < num; i++)
		{
			FontSetting fontSetting = (FontSetting)class1737_0.method_12()[i];
			int startIndex = fontSetting.StartIndex;
			int int_2 = fontSetting.Font.method_21();
			int value2 = method_7(int_2, workbook_0.Worksheets);
			Array.Copy(BitConverter.GetBytes(startIndex), 0, byte_0, num2, 2);
			num2 += 2;
			Array.Copy(BitConverter.GetBytes(value2), 0, byte_0, num2, 2);
			num2 += 2;
		}
	}

	private int method_7(int int_1, WorksheetCollection worksheetCollection_0)
	{
		int num = 0;
		while (true)
		{
			if (num < worksheetCollection_0.method_52().Count)
			{
				Font font = (Font)worksheetCollection_0.method_52()[num];
				if (int_1 == font.method_21())
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}
}
