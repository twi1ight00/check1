using System;
using Aspose.Cells;

namespace ns9;

internal class Class394 : Class316
{
	internal Class394(Worksheet worksheet_0, Workbook workbook_0)
	{
		int_0 = 485;
		byte_0 = new byte[12];
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		Array.Copy(sourceArray, 0, byte_0, 0, 4);
		int value = (int)(worksheet_0.Cells.Columns.Width * (double)workbook_0.Worksheets.method_72() + 5.0) / workbook_0.Worksheets.method_72();
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((int)worksheet_0.Cells.method_0()), 0, byte_0, 6, 2);
		byte b = 0;
		if (worksheet_0.Cells.method_0() == 0.0)
		{
			b = (byte)(b | 2u);
		}
		byte_0[8] = b;
		byte_0[10] = worksheet_0.Cells.method_29();
		byte_0[11] = worksheet_0.Cells.method_27();
	}
}
