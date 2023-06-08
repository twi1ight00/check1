using System;
using Aspose.Cells;

namespace ns27;

internal class Class544 : Class538
{
	internal Class544()
	{
		method_2(2197);
	}

	internal void method_4(DataSorter dataSorter_0, CellArea cellArea_0)
	{
		method_0(38);
		byte_0 = new byte[base.Length];
		byte_0[0] = 149;
		byte_0[1] = 8;
		if (dataSorter_0.SortLeftToRight)
		{
			byte_0[12] |= 1;
		}
		if (dataSorter_0.CaseSensitive)
		{
			byte_0[12] |= 2;
		}
		if (dataSorter_0.string_0 != null && dataSorter_0.string_0 != "")
		{
			byte_0[12] |= 4;
		}
		byte b = 0;
		if (dataSorter_0.method_2() is AutoFilter)
		{
			b = 2;
		}
		byte_0[12] |= (byte)(b << 3);
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartRow), 0, byte_0, 14, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndRow), 0, byte_0, 18, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartColumn), 0, byte_0, 22, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndColumn), 0, byte_0, 26, 4);
		Array.Copy(BitConverter.GetBytes(dataSorter_0.method_0().Count), 0, byte_0, 30, 4);
	}
}
