using System;
using Aspose.Cells;

namespace ns9;

internal class Class341 : Class316
{
	internal Class341()
	{
		int_0 = 158;
	}

	internal void method_6(Workbook workbook_0)
	{
		WorksheetCollection worksheets = workbook_0.Worksheets;
		WorkbookSettings settings = workbook_0.Settings;
		byte_0 = new byte[29];
		Array.Copy(BitConverter.GetBytes(settings.method_12()), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(settings.method_14()), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(settings.method_16()), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(settings.method_18()), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes(settings.SheetTabBarWidth), 0, byte_0, 16, 4);
		Array.Copy(BitConverter.GetBytes(worksheets.FirstVisibleTab), 0, byte_0, 20, 4);
		Array.Copy(BitConverter.GetBytes(worksheets.ActiveSheetIndex), 0, byte_0, 24, 4);
		int num = 64;
		if (settings.IsHidden)
		{
			num |= 1;
		}
		if (settings.IsMinimized)
		{
			num |= 4;
		}
		if (settings.IsHScrollBarVisible)
		{
			num |= 8;
		}
		if (settings.IsVScrollBarVisible)
		{
			num |= 0x10;
		}
		if (settings.ShowTabs)
		{
			num |= 0x20;
		}
		byte_0[28] = (byte)num;
	}
}
