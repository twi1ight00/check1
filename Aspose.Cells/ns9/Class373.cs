using System;
using Aspose.Cells;

namespace ns9;

internal class Class373 : Class316
{
	internal Class373(CellArea cellArea_0)
	{
		int_0 = 176;
		byte_0 = new byte[16];
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartRow), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndRow), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartColumn), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndColumn), 0, byte_0, 12, 4);
	}
}
