using System;
using Aspose.Cells;

namespace ns9;

internal class Class340 : Class316
{
	internal Class340()
	{
		int_0 = 137;
	}

	internal void method_6(Worksheet worksheet_0)
	{
		byte_0 = new byte[30];
		byte b = 0;
		if (worksheet_0.method_11())
		{
			b = (byte)(b | 2u);
		}
		if (worksheet_0.IsGridlinesVisible)
		{
			b = (byte)(b | 4u);
		}
		if (worksheet_0.IsRowColumnHeadersVisible)
		{
			b = (byte)(b | 8u);
		}
		if (worksheet_0.DisplayZeros)
		{
			b = (byte)(b | 0x10u);
		}
		if (worksheet_0.DisplayRightToLeft)
		{
			b = (byte)(b | 0x20u);
		}
		if (worksheet_0.IsSelected)
		{
			b = (byte)(b | 0x40u);
		}
		if (worksheet_0.IsPageBreakPreview)
		{
			b = (byte)(b | 0x80u);
		}
		byte_0[0] = b;
		b = 0;
		if (worksheet_0.IsOutlineShown)
		{
			b = (byte)(b | 1u);
		}
		byte_0[1] = b;
		Array.Copy(BitConverter.GetBytes(worksheet_0.FirstVisibleRow), 0, byte_0, 6, 4);
		Array.Copy(BitConverter.GetBytes(worksheet_0.FirstVisibleColumn), 0, byte_0, 10, 4);
		Array.Copy(BitConverter.GetBytes(worksheet_0.method_44()), 0, byte_0, 14, 4);
		Array.Copy(BitConverter.GetBytes((ushort)worksheet_0.Zoom), 0, byte_0, 18, 2);
		byte_0[20] = 100;
		byte_0[22] = 60;
		byte_0[24] = 100;
		byte_0[26] = 0;
	}
}
