using System;
using Aspose.Cells;

namespace ns9;

internal class Class407 : Class316
{
	internal Class407()
	{
		int_0 = 151;
	}

	internal void method_6(Worksheet worksheet_0)
	{
		PaneCollection panes = worksheet_0.GetPanes();
		byte_0 = new byte[29];
		Array.Copy(BitConverter.GetBytes((double)panes.method_6()), 0, byte_0, 0, 8);
		Array.Copy(BitConverter.GetBytes((double)panes.method_4()), 0, byte_0, 8, 8);
		Array.Copy(BitConverter.GetBytes(panes.Row), 0, byte_0, 16, 4);
		Array.Copy(BitConverter.GetBytes(panes.Column), 0, byte_0, 20, 4);
		byte_0[24] = panes.method_0();
		if (worksheet_0.method_13())
		{
			byte_0[28] |= 1;
		}
	}
}
