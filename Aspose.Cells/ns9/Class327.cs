using System;
using Aspose.Cells;

namespace ns9;

internal class Class327 : Class316
{
	internal Class327()
	{
		int_0 = 141;
	}

	internal void method_6(Worksheet worksheet_0)
	{
		byte_0 = new byte[10];
		byte b = 0;
		if (worksheet_0.IsSelected)
		{
			b = (byte)(b | 1u);
		}
		byte_0[0] = b;
		Array.Copy(BitConverter.GetBytes(worksheet_0.Zoom), 0, byte_0, 2, 4);
	}
}
