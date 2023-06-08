using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class368 : Class316
{
	internal Class368()
	{
		int_0 = 43;
	}

	internal void method_6(Font font_0, Workbook workbook_0)
	{
		int num = 25 + font_0.Name.Length * 2;
		byte_0 = new byte[num];
		Array.Copy(BitConverter.GetBytes((ushort)font_0.method_16()), 0, byte_0, 0, 2);
		int num2 = 0;
		if (font_0.IsItalic)
		{
			num2 |= 2;
		}
		if (font_0.IsStrikeout)
		{
			num2 |= 8;
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)font_0.Weight), 0, byte_0, 4, 2);
		byte_0[6] = font_0.method_8();
		byte_0[8] = (byte)Class1224.smethod_5(font_0.Underline);
		byte_0[9] = font_0.method_11();
		byte_0[10] = font_0.method_2();
		method_4(byte_0, 12, font_0.InternalColor, 64, workbook_0);
		byte_0[20] = Class1224.smethod_39(font_0.method_0());
		int num3 = 21;
		Class1217.smethod_7(byte_0, ref num3, font_0.Name);
	}
}
