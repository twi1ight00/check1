using System;
using Aspose.Cells;
using ns10;
using ns16;
using ns2;

namespace ns9;

internal class Class380 : Class316
{
	internal Class380()
	{
		int_0 = 19;
	}

	internal void method_6(string string_0)
	{
		byte_0 = new byte[5 + string_0.Length * 2];
		int num = 1;
		Class1217.smethod_7(byte_0, ref num, string_0);
	}

	internal void method_7(Class1720 class1720_0, Workbook workbook_0)
	{
		byte[] array = class1720_0.method_2();
		int num = array.Length;
		byte_0 = new byte[5 + class1720_0.string_0.Length * 2 + 4 + num];
		byte_0[0] = 1;
		int num2 = 1;
		Class1217.smethod_7(byte_0, ref num2, class1720_0.string_0);
		Array.Copy(BitConverter.GetBytes(array.Length / 4), 0, byte_0, num2, 4);
		num2 += 4;
		for (int i = 0; i < num; i += 4)
		{
			int value = Class1618.smethod_11(array, i);
			int int_ = Class1618.smethod_11(array, i + 2);
			int value2 = method_8(int_, workbook_0.Worksheets);
			Array.Copy(BitConverter.GetBytes(value), 0, byte_0, num2, 2);
			num2 += 2;
			Array.Copy(BitConverter.GetBytes(value2), 0, byte_0, num2, 2);
			num2 += 2;
		}
	}

	private int method_8(int int_1, WorksheetCollection worksheetCollection_0)
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
