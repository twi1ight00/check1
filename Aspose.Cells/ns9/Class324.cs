using System;
using Aspose.Cells;

namespace ns9;

internal class Class324 : Class316
{
	internal Class324(Worksheet worksheet_0)
	{
		int_0 = 394;
		byte_0 = new byte[8];
		Array.Copy(BitConverter.GetBytes(worksheet_0.VerticalPageBreaks.Count), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(worksheet_0.VerticalPageBreaks.Count), 0, byte_0, 4, 4);
	}
}
