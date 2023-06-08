using System;
using Aspose.Cells;

namespace ns9;

internal class Class393 : Class316
{
	internal Class393(WorksheetCollection worksheetCollection_0)
	{
		int_0 = 534;
		byte_0 = new byte[6];
		Array.Copy(BitConverter.GetBytes(worksheetCollection_0.method_81()), 0, byte_0, 0, 2);
		if (worksheetCollection_0.method_79())
		{
			byte_0[4] |= 1;
		}
		if (worksheetCollection_0.method_77())
		{
			byte_0[4] |= 2;
		}
	}
}
