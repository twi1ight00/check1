using System;
using Aspose.Cells;

namespace ns9;

internal class Class332 : Class316
{
	internal Class332(Worksheet worksheet_0)
	{
		int_0 = 392;
		byte_0 = new byte[8];
		Array.Copy(BitConverter.GetBytes(worksheet_0.HorizontalPageBreaks.Count), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(worksheet_0.HorizontalPageBreaks.Count), 0, byte_0, 4, 4);
	}
}
