using System;
using Aspose.Cells;

namespace ns27;

internal class Class664 : Class538
{
	public Class664(CellArea cellArea_0)
	{
		method_2(222);
		method_0(8);
		byte_0 = new byte[8];
		byte_0[0] = 12;
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartRow), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndRow), 0, byte_0, 4, 2);
		byte_0[6] = (byte)cellArea_0.StartColumn;
		byte_0[7] = (byte)cellArea_0.EndColumn;
	}
}
