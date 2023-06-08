using System;
using Aspose.Cells;

namespace ns27;

internal class Class718 : Class538
{
	internal Class718(WorksheetCollection worksheetCollection_0)
	{
		method_2(61);
		method_0(18);
		byte_0 = new byte[18];
		WorkbookSettings settings = worksheetCollection_0.Workbook.Settings;
		Array.Copy(BitConverter.GetBytes((ushort)settings.method_12()), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)settings.method_14()), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)settings.method_16()), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)settings.method_18()), 0, byte_0, 6, 2);
		byte_0[14] = 1;
		byte_0[16] = 88;
		byte_0[17] = 2;
		Array.Copy(BitConverter.GetBytes((ushort)worksheetCollection_0.ActiveSheetIndex), 0, byte_0, 10, 2);
		Array.Copy(BitConverter.GetBytes((ushort)worksheetCollection_0.FirstVisibleTab), 0, byte_0, 12, 2);
		Array.Copy(BitConverter.GetBytes((ushort)settings.SheetTabBarWidth), 0, byte_0, 16, 2);
		if (settings.IsHidden)
		{
			byte_0[8] |= 1;
		}
		if (settings.IsMinimized)
		{
			byte_0[8] |= 2;
		}
		if (settings.IsHScrollBarVisible)
		{
			byte_0[8] |= 8;
		}
		if (settings.IsVScrollBarVisible)
		{
			byte_0[8] |= 16;
		}
		if (settings.ShowTabs)
		{
			byte_0[8] |= 32;
		}
	}
}
